using System.CodeDom.Compiler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace openencoder
{
    /// <summary>
    /// There are no comments for presetsConfiguration in the schema.
    /// </summary>
    [GeneratedCode("Devart Entity Developer", "")]
    public partial class presetsConfiguration : IEntityTypeConfiguration<presets>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<presets> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<presets> builder)
        {
            builder.ToTable(@"presets", @"public");
            builder.Property(x => x.id).HasColumnName(@"id").HasColumnType(@"serial").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.name).HasColumnName(@"name").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(128);
            builder.Property(x => x.description).HasColumnName(@"description").HasColumnType(@"varchar").ValueGeneratedNever();
            builder.Property(x => x.data).HasColumnName(@"data").HasColumnType(@"varchar").ValueGeneratedNever();
            builder.Property(x => x.active).HasColumnName(@"active").HasColumnType(@"bool").ValueGeneratedNever().HasDefaultValueSql(@"false");
            builder.Property(x => x.output).HasColumnName(@"output").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(128);
            builder.HasKey(@"id");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<presets> builder);

        #endregion
    }

    /// <summary>
    /// There are no comments for usersConfiguration in the schema.
    /// </summary>
    [GeneratedCode("Devart Entity Developer", "")]
    public partial class usersConfiguration : IEntityTypeConfiguration<users>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<users> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<users> builder)
        {
            builder.ToTable(@"users", @"public");
            builder.Property(x => x.username).HasColumnName(@"username").HasColumnType(@"varchar").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            builder.Property(x => x.id).HasColumnName(@"id").HasColumnType(@"serial").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.password).HasColumnName(@"password").HasColumnType(@"varchar").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            builder.Property(x => x.role).HasColumnName(@"role").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.force_password_reset).HasColumnName(@"force_password_reset").HasColumnType(@"bool").ValueGeneratedNever().HasDefaultValueSql(@"false");
            builder.Property(x => x.active).HasColumnName(@"active").HasColumnType(@"bool").ValueGeneratedNever().HasDefaultValueSql(@"true");
            builder.HasKey(@"username");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<users> builder);

        #endregion
    }

    /// <summary>
    /// There are no comments for settings_optionConfiguration in the schema.
    /// </summary>
    [GeneratedCode("Devart Entity Developer", "")]
    public partial class settings_optionConfiguration : IEntityTypeConfiguration<settings_option>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<settings_option> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<settings_option> builder)
        {
            builder.HasNoKey();
            builder.ToView(@"settings_option", @"public");
            builder.Property(x => x.id).HasColumnName(@"id").HasColumnType(@"serial").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.name).HasColumnName(@"name").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.description).HasColumnName(@"description").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(1024);
            builder.Property(x => x.title).HasColumnName(@"title").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.secure).HasColumnName(@"secure").HasColumnType(@"bool").ValueGeneratedNever().HasDefaultValueSql(@"false");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<settings_option> builder);

        #endregion
    }

    /// <summary>
    /// There are no comments for settingsConfiguration in the schema.
    /// </summary>
    [GeneratedCode("Devart Entity Developer", "")]
    public partial class settingsConfiguration : IEntityTypeConfiguration<settings>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<settings> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<settings> builder)
        {
            builder.ToTable(@"settings", @"public");
            builder.Property(x => x.id).HasColumnName(@"id").HasColumnType(@"serial").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.settings_option_id).HasColumnName(@"settings_option_id").HasColumnType(@"int4").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.value).HasColumnName(@"value").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(256);
            builder.Property(x => x.encrypted).HasColumnName(@"encrypted").HasColumnType(@"bool").ValueGeneratedNever().HasDefaultValueSql(@"false");
            builder.HasKey(@"id");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<settings> builder);

        #endregion
    }

    /// <summary>
    /// There are no comments for jobsConfiguration in the schema.
    /// </summary>
    [GeneratedCode("Devart Entity Developer", "")]
    public partial class jobsConfiguration : IEntityTypeConfiguration<jobs>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<jobs> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<jobs> builder)
        {
            builder.ToTable(@"jobs", @"public");
            builder.Property(x => x.guid).HasColumnName(@"guid").HasColumnType(@"varchar").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            builder.Property(x => x.id).HasColumnName(@"id").HasColumnType(@"serial").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.preset).HasColumnName(@"preset").HasColumnType(@"varchar").IsRequired().ValueGeneratedNever().HasMaxLength(128);
            builder.Property(x => x.created_date).HasColumnName(@"created_date").HasColumnType(@"timestamp").ValueGeneratedOnAdd().HasDefaultValueSql(@"CURRENT_TIMESTAMP");
            builder.Property(x => x.status).HasColumnName(@"status").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.source).HasColumnName(@"source").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(128);
            builder.Property(x => x.destination).HasColumnName(@"destination").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(128);
            builder.HasKey(@"guid");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<jobs> builder);

        #endregion
    }

    /// <summary>
    /// There are no comments for encodeConfiguration in the schema.
    /// </summary>
    [GeneratedCode("Devart Entity Developer", "")]
    public partial class encodeConfiguration : IEntityTypeConfiguration<encode>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<encode> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<encode> builder)
        {
            builder.ToTable(@"encode", @"public");
            builder.Property(x => x.id).HasColumnName(@"id").HasColumnType(@"serial").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.probe).HasColumnName(@"probe").HasColumnType(@"json").ValueGeneratedNever();
            builder.Property(x => x.progress).HasColumnName(@"progress").HasColumnType(@"float8").ValueGeneratedNever().HasDefaultValueSql(@"0");
            builder.Property(x => x.job_id).HasColumnName(@"job_id").HasColumnType(@"int4").ValueGeneratedNever();
            builder.Property(x => x.speed).HasColumnName(@"speed").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(64);
            builder.Property(x => x.fps).HasColumnName(@"fps").HasColumnType(@"float8").ValueGeneratedNever().HasDefaultValueSql(@"0");
            builder.Property(x => x.options).HasColumnName(@"options").HasColumnType(@"json").ValueGeneratedNever();
            builder.HasKey(@"id");
            builder.HasOne(x => x.jobs).WithOne(op => op.encode).OnDelete(DeleteBehavior.Cascade).HasPrincipalKey(typeof(jobs), @"id").HasForeignKey(typeof(encode), @"job_id").IsRequired(false);

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<encode> builder);

        #endregion
    }

    /// <summary>
    /// There are no comments for queue_jobConfiguration in the schema.
    /// </summary>
    [GeneratedCode("Devart Entity Developer", "")]
    public partial class queue_jobConfiguration : IEntityTypeConfiguration<queue_job>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<queue_job> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<queue_job> builder)
        {
            builder.ToTable(@"queue_jobs");
            builder.Property(x => x.guid).HasColumnName(@"guid").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.preset).HasColumnName(@"preset").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.source).HasColumnName(@"source").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.destination).HasColumnName(@"destination").IsRequired().ValueGeneratedNever();
            builder.HasKey(@"guid");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<queue_job> builder);

        #endregion
    }

}
