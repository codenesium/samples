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
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "Integration")]
	public partial class CompositePrimaryKeyIntegrationTests
	{
		public CompositePrimaryKeyIntegrationTests()
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

			var model = new ApiCompositePrimaryKeyClientRequestModel();
			model.SetProperties(2);
			var model2 = new ApiCompositePrimaryKeyClientRequestModel();
			model2.SetProperties(3);
			var request = new List<ApiCompositePrimaryKeyClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCompositePrimaryKeyClientResponseModel>> result = await client.CompositePrimaryKeyBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<CompositePrimaryKey>().ToList()[1].Id2.Should().Be(2);

			context.Set<CompositePrimaryKey>().ToList()[2].Id2.Should().Be(3);
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

			var model = new ApiCompositePrimaryKeyClientRequestModel();
			model.SetProperties(2);
			CreateResponse<ApiCompositePrimaryKeyClientResponseModel> result = await client.CompositePrimaryKeyCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<CompositePrimaryKey>().ToList()[1].Id2.Should().Be(2);

			result.Record.Id2.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiCompositePrimaryKeyServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICompositePrimaryKeyService service = testServer.Host.Services.GetService(typeof(ICompositePrimaryKeyService)) as ICompositePrimaryKeyService;
			ApiCompositePrimaryKeyServerResponseModel model = await service.Get(1);

			ApiCompositePrimaryKeyClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2);

			UpdateResponse<ApiCompositePrimaryKeyClientResponseModel> updateResponse = await client.CompositePrimaryKeyUpdateAsync(model.Id, request);

			context.Entry(context.Set<CompositePrimaryKey>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<CompositePrimaryKey>().ToList()[0].Id2.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Id2.Should().Be(2);
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

			ICompositePrimaryKeyService service = testServer.Host.Services.GetService(typeof(ICompositePrimaryKeyService)) as ICompositePrimaryKeyService;
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			model.SetProperties(2);
			CreateResponse<ApiCompositePrimaryKeyServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CompositePrimaryKeyDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCompositePrimaryKeyServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCompositePrimaryKeyClientResponseModel response = await client.CompositePrimaryKeyGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Id2.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCompositePrimaryKeyClientResponseModel response = await client.CompositePrimaryKeyGetAsync(default(int));

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

			List<ApiCompositePrimaryKeyClientResponseModel> response = await client.CompositePrimaryKeyAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Id2.Should().Be(1);
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
				var result = await client.CompositePrimaryKeyAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>c3456403a560ce43dbc0618d9cf9b666</Hash>
</Codenesium>*/