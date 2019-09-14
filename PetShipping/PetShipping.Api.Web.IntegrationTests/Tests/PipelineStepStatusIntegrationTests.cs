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
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "Integration")]
	public partial class PipelineStepStatusIntegrationTests
	{
		public PipelineStepStatusIntegrationTests()
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

			var model = new ApiPipelineStepStatusClientRequestModel();
			model.SetProperties("B");
			var model2 = new ApiPipelineStepStatusClientRequestModel();
			model2.SetProperties("C");
			var request = new List<ApiPipelineStepStatusClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPipelineStepStatusClientResponseModel>> result = await client.PipelineStepStatusBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PipelineStepStatus>().ToList()[1].Name.Should().Be("B");

			context.Set<PipelineStepStatus>().ToList()[2].Name.Should().Be("C");
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

			var model = new ApiPipelineStepStatusClientRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStepStatusClientResponseModel> result = await client.PipelineStepStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PipelineStepStatus>().ToList()[1].Name.Should().Be("B");

			result.Record.Name.Should().Be("B");
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
			var mapper = new ApiPipelineStepStatusServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPipelineStepStatusService service = testServer.Host.Services.GetService(typeof(IPipelineStepStatusService)) as IPipelineStepStatusService;
			ApiPipelineStepStatusServerResponseModel model = await service.Get(1);

			ApiPipelineStepStatusClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B");

			UpdateResponse<ApiPipelineStepStatusClientResponseModel> updateResponse = await client.PipelineStepStatusUpdateAsync(model.Id, request);

			context.Entry(context.Set<PipelineStepStatus>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PipelineStepStatus>().ToList()[0].Name.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
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

			IPipelineStepStatusService service = testServer.Host.Services.GetService(typeof(IPipelineStepStatusService)) as IPipelineStepStatusService;
			var model = new ApiPipelineStepStatusServerRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStepStatusServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PipelineStepStatusDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPipelineStepStatusServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPipelineStepStatusClientResponseModel response = await client.PipelineStepStatusGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
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
			ApiPipelineStepStatusClientResponseModel response = await client.PipelineStepStatusGetAsync(default(int));

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
			List<ApiPipelineStepStatusClientResponseModel> response = await client.PipelineStepStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepsByPipelineStepStatusIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPipelineStepClientResponseModel> response = await client.PipelineStepsByPipelineStepStatusId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepsByPipelineStepStatusIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPipelineStepClientResponseModel> response = await client.PipelineStepsByPipelineStepStatusId(default(int));

			response.Should().BeEmpty();
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
				var result = await client.PipelineStepStatusAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>6e50d5c685a5ce082301ba560648c1e8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/