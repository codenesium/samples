using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FileServiceNS.Api.DataAccess
{
        public partial class FileTypeRepositoryMoc
        {
                public static ApplicationDbContext GetContext()
                {
                        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                      .Options;
                        return new ApplicationDbContext(options);
                }

                public static Mock<ILogger<FileTypeRepository>> GetLoggerMoc()
                {
                        return new Mock<ILogger<FileTypeRepository>>();
                }
        }

        [Trait("Type", "Unit")]
        [Trait("Table", "FileType")]
        [Trait("Area", "Repositories")]
        public partial class FileTypeRepositoryTests
        {
                [Fact]
                public async void All()
                {
                        Mock<ILogger<FileTypeRepository>> loggerMoc = FileTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = FileTypeRepositoryMoc.GetContext();
                        var repository = new FileTypeRepository(loggerMoc.Object, context);

                        FileType entity = new FileType();
                        context.Set<FileType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.All();

                        record.Should().NotBeEmpty();
                }

                [Fact]
                public async void Get()
                {
                        Mock<ILogger<FileTypeRepository>> loggerMoc = FileTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = FileTypeRepositoryMoc.GetContext();
                        var repository = new FileTypeRepository(loggerMoc.Object, context);

                        FileType entity = new FileType();
                        context.Set<FileType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Create()
                {
                        Mock<ILogger<FileTypeRepository>> loggerMoc = FileTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = FileTypeRepositoryMoc.GetContext();
                        var repository = new FileTypeRepository(loggerMoc.Object, context);

                        var entity = new FileType();
                        await repository.Create(entity);

                        var record = await context.Set<FileType>().FirstOrDefaultAsync();

                        record.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Tracked()
                {
                        Mock<ILogger<FileTypeRepository>> loggerMoc = FileTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = FileTypeRepositoryMoc.GetContext();
                        var repository = new FileTypeRepository(loggerMoc.Object, context);
                        FileType entity = new FileType();
                        context.Set<FileType>().Add(entity);
                        await context.SaveChangesAsync();

                        var record = await repository.Get(entity.Id);

                        await repository.Update(record);

                        var modifiedRecord = context.Set<FileType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Update_Entity_Is_Not_Tracked()
                {
                        Mock<ILogger<FileTypeRepository>> loggerMoc = FileTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = FileTypeRepositoryMoc.GetContext();
                        var repository = new FileTypeRepository(loggerMoc.Object, context);
                        FileType entity = new FileType();
                        context.Set<FileType>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Update(new FileType());

                        var modifiedRecord = context.Set<FileType>().FirstOrDefaultAsync();
                        modifiedRecord.Should().NotBeNull();
                }

                [Fact]
                public async void Delete()
                {
                        Mock<ILogger<FileTypeRepository>> loggerMoc = FileTypeRepositoryMoc.GetLoggerMoc();
                        ApplicationDbContext context = FileTypeRepositoryMoc.GetContext();
                        var repository = new FileTypeRepository(loggerMoc.Object, context);
                        FileType entity = new FileType();
                        context.Set<FileType>().Add(entity);
                        await context.SaveChangesAsync();

                        await repository.Delete(entity.Id);

                        FileType modifiedRecord = await context.Set<FileType>().FirstOrDefaultAsync();

                        modifiedRecord.Should().BeNull();
                }
        }
}

/*<Codenesium>
    <Hash>364d1f4244fdae0d1a433763ba03a541</Hash>
</Codenesium>*/