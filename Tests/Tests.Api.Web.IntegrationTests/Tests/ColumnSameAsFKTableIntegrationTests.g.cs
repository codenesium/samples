using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Integration")]
	public partial class ColumnSameAsFKTableIntegrationTests
	{
		public ColumnSameAsFKTableIntegrationTests()
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

			var model = new ApiColumnSameAsFKTableClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiColumnSameAsFKTableClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiColumnSameAsFKTableClientRequestModel>() {model, model2};
			CreateResponse<List<ApiColumnSameAsFKTableClientResponseModel>> result = await client.ColumnSameAsFKTableBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ColumnSameAsFKTable>().ToList()[1].Person.Should().Be(1);
			context.Set<ColumnSameAsFKTable>().ToList()[1].PersonId.Should().Be(1);

			context.Set<ColumnSameAsFKTable>().ToList()[2].Person.Should().Be(1);
			context.Set<ColumnSameAsFKTable>().ToList()[2].PersonId.Should().Be(1);
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

			var model = new ApiColumnSameAsFKTableClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiColumnSameAsFKTableClientResponseModel> result = await client.ColumnSameAsFKTableCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ColumnSameAsFKTable>().ToList()[1].Person.Should().Be(1);
			context.Set<ColumnSameAsFKTable>().ToList()[1].PersonId.Should().Be(1);

			result.Record.Person.Should().Be(1);
			result.Record.PersonId.Should().Be(1);
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
			var mapper = new ApiColumnSameAsFKTableServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IColumnSameAsFKTableService service = testServer.Host.Services.GetService(typeof(IColumnSameAsFKTableService)) as IColumnSameAsFKTableService;
			ApiColumnSameAsFKTableServerResponseModel model = await service.Get(1);

			ApiColumnSameAsFKTableClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiColumnSameAsFKTableClientResponseModel> updateResponse = await client.ColumnSameAsFKTableUpdateAsync(model.Id, request);

			context.Entry(context.Set<ColumnSameAsFKTable>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<ColumnSameAsFKTable>().ToList()[0].Person.Should().Be(1);
			context.Set<ColumnSameAsFKTable>().ToList()[0].PersonId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Person.Should().Be(1);
			updateResponse.Record.PersonId.Should().Be(1);
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

			IColumnSameAsFKTableService service = testServer.Host.Services.GetService(typeof(IColumnSameAsFKTableService)) as IColumnSameAsFKTableService;
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ColumnSameAsFKTableDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiColumnSameAsFKTableServerResponseModel verifyResponse = await service.Get(2);

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

			ApiColumnSameAsFKTableClientResponseModel response = await client.ColumnSameAsFKTableGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Person.Should().Be(1);
			response.PersonId.Should().Be(1);
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
			ApiColumnSameAsFKTableClientResponseModel response = await client.ColumnSameAsFKTableGetAsync(default(int));

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
			List<ApiColumnSameAsFKTableClientResponseModel> response = await client.ColumnSameAsFKTableAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Person.Should().Be(1);
			response[0].PersonId.Should().Be(1);
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
				var result = await client.ColumnSameAsFKTableAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>b413fafaae246b3d860441f9bb3ad8f6</Hash>
</Codenesium>*/