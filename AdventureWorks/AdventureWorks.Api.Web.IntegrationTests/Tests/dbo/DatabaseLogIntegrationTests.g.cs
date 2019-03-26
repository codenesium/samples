using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "Integration")]
	public partial class DatabaseLogIntegrationTests
	{
		public DatabaseLogIntegrationTests()
		{
		}

		[Fact]
		public virtual async void TestBulkInsert()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());

			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiDatabaseLogClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B");
			var model2 = new ApiDatabaseLogClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C", "C", "C", "C");
			var request = new List<ApiDatabaseLogClientRequestModel>() {model, model2};
			CreateResponse<List<ApiDatabaseLogClientResponseModel>> result = await client.DatabaseLogBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<DatabaseLog>().ToList()[1].DatabaseUser.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].PostTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<DatabaseLog>().ToList()[1].ReservedEvent.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].ReservedObject.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].Schema.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].Tsql.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].XmlEvent.Should().Be("B");

			context.Set<DatabaseLog>().ToList()[2].DatabaseUser.Should().Be("C");
			context.Set<DatabaseLog>().ToList()[2].PostTime.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<DatabaseLog>().ToList()[2].ReservedEvent.Should().Be("C");
			context.Set<DatabaseLog>().ToList()[2].ReservedObject.Should().Be("C");
			context.Set<DatabaseLog>().ToList()[2].Schema.Should().Be("C");
			context.Set<DatabaseLog>().ToList()[2].Tsql.Should().Be("C");
			context.Set<DatabaseLog>().ToList()[2].XmlEvent.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiDatabaseLogClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B");
			CreateResponse<ApiDatabaseLogClientResponseModel> result = await client.DatabaseLogCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<DatabaseLog>().ToList()[1].DatabaseUser.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].PostTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<DatabaseLog>().ToList()[1].ReservedEvent.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].ReservedObject.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].Schema.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].Tsql.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[1].XmlEvent.Should().Be("B");

			result.Record.DatabaseUser.Should().Be("B");
			result.Record.PostTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ReservedEvent.Should().Be("B");
			result.Record.ReservedObject.Should().Be("B");
			result.Record.Schema.Should().Be("B");
			result.Record.Tsql.Should().Be("B");
			result.Record.XmlEvent.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiDatabaseLogServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IDatabaseLogService service = testServer.Host.Services.GetService(typeof(IDatabaseLogService)) as IDatabaseLogService;
			ApiDatabaseLogServerResponseModel model = await service.Get(1);

			ApiDatabaseLogClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B");

			UpdateResponse<ApiDatabaseLogClientResponseModel> updateResponse = await client.DatabaseLogUpdateAsync(model.DatabaseLogID, request);

			context.Entry(context.Set<DatabaseLog>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.DatabaseLogID.Should().Be(1);
			context.Set<DatabaseLog>().ToList()[0].DatabaseUser.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[0].PostTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<DatabaseLog>().ToList()[0].ReservedEvent.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[0].ReservedObject.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[0].Schema.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[0].Tsql.Should().Be("B");
			context.Set<DatabaseLog>().ToList()[0].XmlEvent.Should().Be("B");

			updateResponse.Record.DatabaseLogID.Should().Be(1);
			updateResponse.Record.DatabaseUser.Should().Be("B");
			updateResponse.Record.PostTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ReservedEvent.Should().Be("B");
			updateResponse.Record.ReservedObject.Should().Be("B");
			updateResponse.Record.Schema.Should().Be("B");
			updateResponse.Record.Tsql.Should().Be("B");
			updateResponse.Record.XmlEvent.Should().Be("B");
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IDatabaseLogService service = testServer.Host.Services.GetService(typeof(IDatabaseLogService)) as IDatabaseLogService;
			var model = new ApiDatabaseLogServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B");
			CreateResponse<ApiDatabaseLogServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.DatabaseLogDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiDatabaseLogServerResponseModel verifyResponse = await service.Get(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public virtual async void TestGetFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiDatabaseLogClientResponseModel response = await client.DatabaseLogGetAsync(1);

			response.Should().NotBeNull();
			response.DatabaseLogID.Should().Be(1);
			response.DatabaseUser.Should().Be("A");
			response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReservedEvent.Should().Be("A");
			response.ReservedObject.Should().Be("A");
			response.Schema.Should().Be("A");
			response.Tsql.Should().Be("A");
			response.XmlEvent.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiDatabaseLogClientResponseModel response = await client.DatabaseLogGetAsync(default(int));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiDatabaseLogClientResponseModel> response = await client.DatabaseLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].DatabaseLogID.Should().Be(1);
			response[0].DatabaseUser.Should().Be("A");
			response[0].PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ReservedEvent.Should().Be("A");
			response[0].ReservedObject.Should().Be("A");
			response[0].Schema.Should().Be("A");
			response[0].Tsql.Should().Be("A");
			response[0].XmlEvent.Should().Be("A");
		}

		[Fact]
		public virtual void TestClientCancellationToken()
		{
			Func<Task> testCancellation = async () =>
			{
				var builder = new WebHostBuilder()
				              .UseEnvironment("Production")
				              .UseStartup<TestStartup>();
				TestServer testServer = new TestServer(builder);

				var client = new ApiClient(testServer.BaseAddress.OriginalString);
				CancellationTokenSource tokenSource = new CancellationTokenSource();
				CancellationToken token = tokenSource.Token;
				tokenSource.Cancel();
				var result = await client.DatabaseLogAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>be06346a7b0d48db74f147229e45195f</Hash>
</Codenesium>*/