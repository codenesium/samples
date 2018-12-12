using ESPIOTNS.Api.Client;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
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

namespace ESPIOTNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "Integration")]
	public partial class EfmigrationshistoryIntegrationTests
	{
		public EfmigrationshistoryIntegrationTests()
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiEfmigrationshistoryClientRequestModel();
			model.SetProperties("B");
			var model2 = new ApiEfmigrationshistoryClientRequestModel();
			model2.SetProperties("C");
			var request = new List<ApiEfmigrationshistoryClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEfmigrationshistoryClientResponseModel>> result = await client.EfmigrationshistoryBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Efmigrationshistory>().ToList()[1].ProductVersion.Should().Be("B");

			context.Set<Efmigrationshistory>().ToList()[2].ProductVersion.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiEfmigrationshistoryClientRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiEfmigrationshistoryClientResponseModel> result = await client.EfmigrationshistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Efmigrationshistory>().ToList()[1].ProductVersion.Should().Be("B");

			result.Record.ProductVersion.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiEfmigrationshistoryServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IEfmigrationshistoryService service = testServer.Host.Services.GetService(typeof(IEfmigrationshistoryService)) as IEfmigrationshistoryService;
			ApiEfmigrationshistoryServerResponseModel model = await service.Get("A");

			ApiEfmigrationshistoryClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B");

			UpdateResponse<ApiEfmigrationshistoryClientResponseModel> updateResponse = await client.EfmigrationshistoryUpdateAsync(model.MigrationId, request);

			context.Entry(context.Set<Efmigrationshistory>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.MigrationId.Should().Be("A");
			context.Set<Efmigrationshistory>().ToList()[0].ProductVersion.Should().Be("B");

			updateResponse.Record.MigrationId.Should().Be("A");
			updateResponse.Record.ProductVersion.Should().Be("B");
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IEfmigrationshistoryService service = testServer.Host.Services.GetService(typeof(IEfmigrationshistoryService)) as IEfmigrationshistoryService;
			var model = new ApiEfmigrationshistoryServerRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiEfmigrationshistoryServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.EfmigrationshistoryDeleteAsync("B");

			deleteResult.Success.Should().BeTrue();
			ApiEfmigrationshistoryServerResponseModel verifyResponse = await service.Get("B");

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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiEfmigrationshistoryClientResponseModel response = await client.EfmigrationshistoryGetAsync("A");

			response.Should().NotBeNull();
			response.MigrationId.Should().Be("A");
			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiEfmigrationshistoryClientResponseModel response = await client.EfmigrationshistoryGetAsync("test_value");

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

			List<ApiEfmigrationshistoryClientResponseModel> response = await client.EfmigrationshistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].MigrationId.Should().Be("A");
			response[0].ProductVersion.Should().Be("A");
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
				var result = await client.EfmigrationshistoryAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>5a34389db6906c47529e204df6a9a36f</Hash>
</Codenesium>*/