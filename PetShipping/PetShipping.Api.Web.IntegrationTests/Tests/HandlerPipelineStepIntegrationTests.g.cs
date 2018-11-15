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
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "Integration")]
	public partial class HandlerPipelineStepIntegrationTests
	{
		public HandlerPipelineStepIntegrationTests()
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

			var model = new ApiHandlerPipelineStepClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiHandlerPipelineStepClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiHandlerPipelineStepClientRequestModel>() {model, model2};
			CreateResponse<List<ApiHandlerPipelineStepClientResponseModel>> result = await client.HandlerPipelineStepBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<HandlerPipelineStep>().ToList()[1].HandlerId.Should().Be(1);
			context.Set<HandlerPipelineStep>().ToList()[1].PipelineStepId.Should().Be(1);

			context.Set<HandlerPipelineStep>().ToList()[2].HandlerId.Should().Be(1);
			context.Set<HandlerPipelineStep>().ToList()[2].PipelineStepId.Should().Be(1);
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

			var model = new ApiHandlerPipelineStepClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiHandlerPipelineStepClientResponseModel> result = await client.HandlerPipelineStepCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<HandlerPipelineStep>().ToList()[1].HandlerId.Should().Be(1);
			context.Set<HandlerPipelineStep>().ToList()[1].PipelineStepId.Should().Be(1);

			result.Record.HandlerId.Should().Be(1);
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
			var mapper = new ApiHandlerPipelineStepServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IHandlerPipelineStepService service = testServer.Host.Services.GetService(typeof(IHandlerPipelineStepService)) as IHandlerPipelineStepService;
			ApiHandlerPipelineStepServerResponseModel model = await service.Get(1);

			ApiHandlerPipelineStepClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiHandlerPipelineStepClientResponseModel> updateResponse = await client.HandlerPipelineStepUpdateAsync(model.Id, request);

			context.Entry(context.Set<HandlerPipelineStep>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<HandlerPipelineStep>().ToList()[0].HandlerId.Should().Be(1);
			context.Set<HandlerPipelineStep>().ToList()[0].PipelineStepId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.HandlerId.Should().Be(1);
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IHandlerPipelineStepService service = testServer.Host.Services.GetService(typeof(IHandlerPipelineStepService)) as IHandlerPipelineStepService;
			var model = new ApiHandlerPipelineStepServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiHandlerPipelineStepServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.HandlerPipelineStepDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiHandlerPipelineStepServerResponseModel verifyResponse = await service.Get(2);

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

			ApiHandlerPipelineStepClientResponseModel response = await client.HandlerPipelineStepGetAsync(1);

			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
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
			ApiHandlerPipelineStepClientResponseModel response = await client.HandlerPipelineStepGetAsync(default(int));

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

			List<ApiHandlerPipelineStepClientResponseModel> response = await client.HandlerPipelineStepAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].HandlerId.Should().Be(1);
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
				var result = await client.HandlerPipelineStepAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>8e3020fb2a5ce6764b7a669a48811c48</Hash>
</Codenesium>*/