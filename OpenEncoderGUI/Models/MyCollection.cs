using System.Collections.ObjectModel;
using System.IO;

namespace OpenEncoder
{
    public class MyCollection
    {
        public int? id { get; set; }
        public string? source { get; set; }
        public string? status { get; set; }
        public double? progress { get; set; }
    }

    public class Status
    {
        public string? nome { get; set; }
        public int? count { get; set; }
        public double? porcentagem { get; set; }
    }

    public class Health
    {
        public string? nome { get; set; }
        public bool? status { get; set; }
    }
    public class HeartBeat
    {
        public string? worker { get; set; }
        public string? db { get; set; }
    }

    public class Node
    {
        public ObservableCollection<Node>? Subfolders { get; set; }

        public string strNodeText { get; }
        public string strFullPath { get; }

        public Node(string _strFullPath)
        {
            strFullPath = _strFullPath;
            strNodeText = Path.GetFileName(_strFullPath);
        }
    }

}
