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
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "Integration")]
	public partial class OtherTransportIntegrationTests
	{
		public OtherTransportIntegrationTests()
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

			var model = new ApiOtherTransportClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiOtherTransportClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiOtherTransportClientRequestModel>() {model, model2};
			CreateResponse<List<ApiOtherTransportClientResponseModel>> result = await client.OtherTransportBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<OtherTransport>().ToList()[1].HandlerId.Should().Be(1);
			context.Set<OtherTransport>().ToList()[1].PipelineStepId.Should().Be(1);

			context.Set<OtherTransport>().ToList()[2].HandlerId.Should().Be(1);
			context.Set<OtherTransport>().ToList()[2].PipelineStepId.Should().Be(1);
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

			var model = new ApiOtherTransportClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiOtherTransportClientResponseModel> result = await client.OtherTransportCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<OtherTransport>().ToList()[1].HandlerId.Should().Be(1);
			context.Set<OtherTransport>().ToList()[1].PipelineStepId.Should().Be(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			var mapper = new ApiOtherTransportServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IOtherTransportService service = testServer.Host.Services.GetService(typeof(IOtherTransportService)) as IOtherTransportService;
			ApiOtherTransportServerResponseModel model = await service.Get(1);

			ApiOtherTransportClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiOtherTransportClientResponseModel> updateResponse = await client.OtherTransportUpdateAsync(model.Id, request);

			context.Entry(context.Set<OtherTransport>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<OtherTransport>().ToList()[0].HandlerId.Should().Be(1);
			context.Set<OtherTransport>().ToList()[0].PipelineStepId.Should().Be(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IOtherTransportService service = testServer.Host.Services.GetService(typeof(IOtherTransportService)) as IOtherTransportService;
			var model = new ApiOtherTransportServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiOtherTransportServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.OtherTransportDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiOtherTransportServerResponseModel verifyResponse = await service.Get(2);

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

			ApiOtherTransportClientResponseModel response = await client.OtherTransportGetAsync(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiOtherTransportClientResponseModel response = await client.OtherTransportGetAsync(default(int));

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
			List<ApiOtherTransportClientResponseModel> response = await client.OtherTransportAllAsync();

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
				var result = await client.OtherTransportAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>35f4640635d021acda978dd41e5f7617</Hash>
</Codenesium>*/