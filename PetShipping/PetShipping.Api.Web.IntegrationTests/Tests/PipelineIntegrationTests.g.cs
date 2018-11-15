using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "Integration")]
	public partial class PipelineIntegrationTests
	{
		public PipelineIntegrationTests()
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

			var model = new ApiPipelineClientRequestModel();
			model.SetProperties(1, 2);
			var model2 = new ApiPipelineClientRequestModel();
			model2.SetProperties(1, 3);
			var request = new List<ApiPipelineClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPipelineClientResponseModel>> result = await client.PipelineBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Pipeline>().ToList()[1].PipelineStatusId.Should().Be(1);
			context.Set<Pipeline>().ToList()[1].SaleId.Should().Be(2);

			context.Set<Pipeline>().ToList()[2].PipelineStatusId.Should().Be(1);
			context.Set<Pipeline>().ToList()[2].SaleId.Should().Be(3);
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

			var model = new ApiPipelineClientRequestModel();
			model.SetProperties(1, 2);
			CreateResponse<ApiPipelineClientResponseModel> result = await client.PipelineCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Pipeline>().ToList()[1].PipelineStatusId.Should().Be(1);
			context.Set<Pipeline>().ToList()[1].SaleId.Should().Be(2);

			result.Record.PipelineStatusId.Should().Be(1);
			result.Record.SaleId.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiPipelineServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPipelineService service = testServer.Host.Services.GetService(typeof(IPipelineService)) as IPipelineService;
			ApiPipelineServerResponseModel model = await service.Get(1);

			ApiPipelineClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 2);

			UpdateResponse<ApiPipelineClientResponseModel> updateResponse = await client.PipelineUpdateAsync(model.Id, request);

			context.Entry(context.Set<Pipeline>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Pipeline>().ToList()[0].PipelineStatusId.Should().Be(1);
			context.Set<Pipeline>().ToList()[0].SaleId.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.PipelineStatusId.Should().Be(1);
			updateResponse.Record.SaleId.Should().Be(2);
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

			IPipelineService service = testServer.Host.Services.GetService(typeof(IPipelineService)) as IPipelineService;
			var model = new ApiPipelineServerRequestModel();
			model.SetProperties(1, 2);
			CreateResponse<ApiPipelineServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PipelineDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPipelineServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPipelineClientResponseModel response = await client.PipelineGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPipelineClientResponseModel response = await client.PipelineGetAsync(default(int));

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

			List<ApiPipelineClientResponseModel> response = await client.PipelineAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].PipelineStatusId.Should().Be(1);
			response[0].SaleId.Should().Be(1);
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
				var result = await client.PipelineAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>628efb9f881188d0d78f1e2fa7a880a9</Hash>
</Codenesium>*/