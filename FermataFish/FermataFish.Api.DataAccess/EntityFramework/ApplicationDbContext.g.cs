using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace FermataFishNS.Api.DataAccess
{
        public partial class ApplicationDbContext : DbContext
        {
                public Guid UserId { get; private set; }

                public int TenantId { get; private set; }

                public ApplicationDbContext(DbContextOptions options)
                        : base(options)
                {
                }

                public void SetUserId(Guid userId)
                {
                        if (userId == default(Guid))
                        {
                                throw new ArgumentException("UserId cannot be a default value");
                        }

                        this.UserId = userId;
                }

                public void SetTenantId(int tenantId)
                {
                        if (tenantId <= 0)
                        {
                                throw new ArgumentException("TenantId must be greater than 0");
                        }

                        this.TenantId = tenantId;
                }

                public virtual DbSet<Admin> Admins { get; set; }

                public virtual DbSet<Family> Families { get; set; }

                public virtual DbSet<Lesson> Lessons { get; set; }

                public virtual DbSet<LessonStatus> LessonStatus { get; set; }

                public virtual DbSet<LessonXStudent> LessonXStudents { get; set; }

                public virtual DbSet<LessonXTeacher> LessonXTeachers { get; set; }

                public virtual DbSet<Rate> Rates { get; set; }

                public virtual DbSet<Space> Spaces { get; set; }

                public virtual DbSet<SpaceFeature> SpaceFeatures { get; set; }

                public virtual DbSet<SpaceXSpaceFeature> SpaceXSpaceFeatures { get; set; }

                public virtual DbSet<State> States { get; set; }

                public virtual DbSet<Student> Students { get; set; }

                public virtual DbSet<StudentXFamily> StudentXFamilies { get; set; }

                public virtual DbSet<Studio> Studios { get; set; }

                public virtual DbSet<Teacher> Teachers { get; set; }

                public virtual DbSet<TeacherSkill> TeacherSkills { get; set; }

                public virtual DbSet<TeacherXTeacherSkill> TeacherXTeacherSkills { get; set; }

                protected override void OnConfiguring(DbContextOptionsBuilder options)
                {
                        base.OnConfiguring(options);
                }
        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
                public ApplicationDbContext CreateDbContext(string[] args)
                {
                        string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "FermataFish.Api.Web");

                        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                        IConfigurationRoot configuration = new ConfigurationBuilder()
                                                           .SetBasePath(settingsDirectory)
                                                           .AddJsonFile($"appsettings.{environment}.json")
                                                           .Build();

                        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

                        var connectionString = configuration.GetConnectionString("ApplicationDbContext");

                        builder.UseSqlServer(connectionString);

                        return new ApplicationDbContext(builder.Options);
                }
        }
}

/*<Codenesium>
    <Hash>1a0a09c0d7a0577e820e19555cf4c841</Hash>
</Codenesium>*/