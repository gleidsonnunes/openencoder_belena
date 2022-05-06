using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace openencoder.Controllers;

[Produces("application/json")]
[Route("/api/[controller]")]
[ApiController]
public class ApiController : Controller
{
    private readonly OpenEncoderModel context = new();

    [HttpGet("/api/", Name = "GetApi")]
    public IActionResult Get()
    {
        return new JsonResult(JsonSerializer.Deserialize<object>($"{{\"Name\": \"openencoder\",\"Version\": \"{Environment.Version}\",\"GitHub\": \"https://github.com/gleidsonnunes/openencoder\",\"Docs\": \"https://github.com/alfg/openencoder/blob/master/API.md\"}}"));

    }

    [HttpGet("/api/health")]
    public async Task<IActionResult> Health()
    {
        string dbHealth = "OK", workerHealth = "OK";

        HttpClient http = new();
        HeartBeat? h = JsonSerializer.Deserialize<HeartBeat>(await http.GetStringAsync("http://gleidson-nunes.ddns.net:85/api/HeartBeat"));

        if (!context.Database.CanConnect())
        {
            dbHealth = "NOTOK";
        }

        if (!(h?.db == "OK"))
        {
            dbHealth = "NOTOK";
        }

        if (!(h?.worker == "OK"))
        {
            workerHealth = "NOTOK";
        }

        return new JsonResult(JsonSerializer.Deserialize<object>($"{{\"api\":\"OK\",\"database\":\"{dbHealth}\",\"worker\": \"{workerHealth}\"}}"));
    }

    [HttpGet("/api/stats")]
    public IActionResult Stats()
    {
        try
        {
            var stats = context.jobs.GroupBy(a => a.status).Select(a => new { count = a.Count(), status = a.First().status }).ToList();
            return new JsonResult(JsonSerializer.Deserialize<object>($"{{\"status\": 200,\"stats\":{{\"jobs\": {JsonSerializer.Serialize(stats)}}}}}"));
        }
        catch (Exception ex)
        {
            return new JsonResult(JsonSerializer.Deserialize<object>($"{{\"status\":  400,\"message\": \"{ex.Message}\"}}"));
        }
    }

    [HttpGet("/api/jobs")]
    public IActionResult Jobs(int page = 1, int count = 10)
    {
        try
        {
            if (page == 0)
            {
                page = 1;
            }

            if (count == 0)
            {
                count = 10;
            }

            var result = context.jobs.Join(context.encode, a => a.id, b => b.job_id, (a, b) => new { jobs = a, encode = b }).OrderByDescending(a => a.jobs.id).ToList().Take(new Range(new Index((page - 1) * count), new Index(page * count))).Select(a => new { a.jobs.status, a.jobs.guid, a.jobs.preset, a.jobs.source, a.jobs.destination, a.jobs.created_date, a.jobs.id, a.encode.progress, a.encode.fps, a.encode.options, a.encode.probe, a.encode.speed }).ToList();
            return new JsonResult(JsonSerializer.Deserialize<object>($"{{\"count\": {context.jobs.Count()},\"items\": {JsonSerializer.Serialize(result)}}}"));
        }
        catch (Exception ex)
        {
            return new JsonResult(JsonSerializer.Deserialize<object>($"{{\"status\":  400,\"message\": \"{ex.Message}\"}}"));
        }
    }
}