using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class CertificateRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<CertificateRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<CertificateRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "Certificate")]
        [Trait("Area", "Repositories")]
        public partial class CertificateRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<CertificateRepository>> loggerMoc = CertificateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CertificateRepositoryMoc.GetContext();
                        var repository = new CertificateRepository(loggerMoc.Object, context);

                        Certificate entity = new Certificate();

                        context.Set<Certificate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<CertificateRepository>> loggerMoc = CertificateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CertificateRepositoryMoc.GetContext();
                        var repository = new CertificateRepository(loggerMoc.Object, context);

                        Certificate entity = new Certificate();

                        context.Set<Certificate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<CertificateRepository>> loggerMoc = CertificateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CertificateRepositoryMoc.GetContext();
                        var repository = new CertificateRepository(loggerMoc.Object, context);

                        var entity = new Certificate();

                        await repository.Create(entity);

                        var record = await context.Set<Certificate>().FirstOrDefaultAsync();
                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<CertificateRepository>> loggerMoc = CertificateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CertificateRepositoryMoc.GetContext();
                        var repository = new CertificateRepository(loggerMoc.Object, context);

                        Certificate entity = new Certificate();

                        context.Set<Certificate>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<Certificate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<CertificateRepository>> loggerMoc = CertificateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CertificateRepositoryMoc.GetContext();
                        var repository = new CertificateRepository(loggerMoc.Object, context);

                        Certificate entity = new Certificate();

                        context.Set<Certificate>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new Certificate());

                        var modifiedRecord = context.Set<Certificate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<CertificateRepository>> loggerMoc = CertificateRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = CertificateRepositoryMoc.GetContext();
                        var repository = new CertificateRepository(loggerMoc.Object, context);

                        Certificate entity = new Certificate();

                        context.Set<Certificate>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        Certificate modifiedRecord = await context.Set<Certificate>().FirstOrDefaultAsync();
                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>4e593bc157cdb648c0b56cb4ecb454ea</Hash>
</Codenesium>*/