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
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "Integration")]
	public partial class PipelineStepDestinationIntegrationTests
	{
		public PipelineStepDestinationIntegrationTests()
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

			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiPipelineStepDestinationClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiPipelineStepDestinationClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiPipelineStepDestinationClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPipelineStepDestinationClientResponseModel>> result = await client.PipelineStepDestinationBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PipelineStepDestination>().ToList()[1].DestinationId.Should().Be(1);
			context.Set<PipelineStepDestination>().ToList()[1].PipelineStepId.Should().Be(1);

			context.Set<PipelineStepDestination>().ToList()[2].DestinationId.Should().Be(1);
			context.Set<PipelineStepDestination>().ToList()[2].PipelineStepId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiPipelineStepDestinationClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiPipelineStepDestinationClientResponseModel> result = await client.PipelineStepDestinationCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PipelineStepDestination>().ToList()[1].DestinationId.Should().Be(1);
			context.Set<PipelineStepDestination>().ToList()[1].PipelineStepId.Should().Be(1);

			result.Record.DestinationId.Should().Be(1);
			result.Record.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			var mapper = new ApiPipelineStepDestinationServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPipelineStepDestinationService service = testServer.Host.Services.GetService(typeof(IPipelineStepDestinationService)) as IPipelineStepDestinationService;
			ApiPipelineStepDestinationServerResponseModel model = await service.Get(1);

			ApiPipelineStepDestinationClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiPipelineStepDestinationClientResponseModel> updateResponse = await client.PipelineStepDestinationUpdateAsync(model.Id, request);

			context.Entry(context.Set<PipelineStepDestination>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PipelineStepDestination>().ToList()[0].DestinationId.Should().Be(1);
			context.Set<PipelineStepDestination>().ToList()[0].PipelineStepId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.DestinationId.Should().Be(1);
			updateResponse.Record.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IPipelineStepDestinationService service = testServer.Host.Services.GetService(typeof(IPipelineStepDestinationService)) as IPipelineStepDestinationService;
			var model = new ApiPipelineStepDestinationServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiPipelineStepDestinationServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PipelineStepDestinationDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPipelineStepDestinationServerResponseModel verifyResponse = await service.Get(2);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiPipelineStepDestinationClientResponseModel response = await client.PipelineStepDestinationGetAsync(1);

			response.Should().NotBeNull();
			response.DestinationId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiPipelineStepDestinationClientResponseModel response = await client.PipelineStepDestinationGetAsync(default(int));

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPipelineStepDestinationClientResponseModel> response = await client.PipelineStepDestinationAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].DestinationId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].PipelineStepId.Should().Be(1);
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
				var result = await client.PipelineStepDestinationAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>15c2c82ef1d563221e3b472c0e57988b</Hash>
</Codenesium>*/