using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class ClientCommunicationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ClientCommunicationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ClientCommunicationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "Repositories")]
	public partial class ClientCommunicationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ClientCommunicationRepository>> loggerMoc = ClientCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ClientCommunicationRepositoryMoc.GetContext();
			var repository = new ClientCommunicationRepository(loggerMoc.Object, context);

			ClientCommunication entity = new ClientCommunication();
			context.Set<ClientCommunication>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ClientCommunicationRepository>> loggerMoc = ClientCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ClientCommunicationRepositoryMoc.GetContext();
			var repository = new ClientCommunicationRepository(loggerMoc.Object, context);

			ClientCommunication entity = new ClientCommunication();
			context.Set<ClientCommunication>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ClientCommunicationRepository>> loggerMoc = ClientCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ClientCommunicationRepositoryMoc.GetContext();
			var repository = new ClientCommunicationRepository(loggerMoc.Object, context);

			var entity = new ClientCommunication();
			await repository.Create(entity);

			var record = await context.Set<ClientCommunication>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ClientCommunicationRepository>> loggerMoc = ClientCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ClientCommunicationRepositoryMoc.GetContext();
			var repository = new ClientCommunicationRepository(loggerMoc.Object, context);
			ClientCommunication entity = new ClientCommunication();
			context.Set<ClientCommunication>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ClientCommunication>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ClientCommunicationRepository>> loggerMoc = ClientCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ClientCommunicationRepositoryMoc.GetContext();
			var repository = new ClientCommunicationRepository(loggerMoc.Object, context);
			ClientCommunication entity = new ClientCommunication();
			context.Set<ClientCommunication>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ClientCommunication());

			var modifiedRecord = context.Set<ClientCommunication>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ClientCommunicationRepository>> loggerMoc = ClientCommunicationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ClientCommunicationRepositoryMoc.GetContext();
			var repository = new ClientCommunicationRepository(loggerMoc.Object, context);
			ClientCommunication entity = new ClientCommunication();
			context.Set<ClientCommunication>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ClientCommunication modifiedRecord = await context.Set<ClientCommunication>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>cd70634c1072dbc0d7bb09f255a064f4</Hash>
</Codenesium>*/