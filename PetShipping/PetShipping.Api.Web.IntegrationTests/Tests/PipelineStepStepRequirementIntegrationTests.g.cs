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
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "Integration")]
	public partial class PipelineStepStepRequirementIntegrationTests
	{
		public PipelineStepStepRequirementIntegrationTests()
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

			var model = new ApiPipelineStepStepRequirementClientRequestModel();
			model.SetProperties("B", 1, true);
			var model2 = new ApiPipelineStepStepRequirementClientRequestModel();
			model2.SetProperties("C", 1, true);
			var request = new List<ApiPipelineStepStepRequirementClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPipelineStepStepRequirementClientResponseModel>> result = await client.PipelineStepStepRequirementBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PipelineStepStepRequirement>().ToList()[1].Details.Should().Be("B");
			context.Set<PipelineStepStepRequirement>().ToList()[1].PipelineStepId.Should().Be(1);
			context.Set<PipelineStepStepRequirement>().ToList()[1].RequirementMet.Should().Be(true);

			context.Set<PipelineStepStepRequirement>().ToList()[2].Details.Should().Be("C");
			context.Set<PipelineStepStepRequirement>().ToList()[2].PipelineStepId.Should().Be(1);
			context.Set<PipelineStepStepRequirement>().ToList()[2].RequirementMet.Should().Be(true);
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

			var model = new ApiPipelineStepStepRequirementClientRequestModel();
			model.SetProperties("B", 1, true);
			CreateResponse<ApiPipelineStepStepRequirementClientResponseModel> result = await client.PipelineStepStepRequirementCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PipelineStepStepRequirement>().ToList()[1].Details.Should().Be("B");
			context.Set<PipelineStepStepRequirement>().ToList()[1].PipelineStepId.Should().Be(1);
			context.Set<PipelineStepStepRequirement>().ToList()[1].RequirementMet.Should().Be(true);

			result.Record.Details.Should().Be("B");
			result.Record.PipelineStepId.Should().Be(1);
			result.Record.RequirementMet.Should().Be(true);
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
			var mapper = new ApiPipelineStepStepRequirementServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPipelineStepStepRequirementService service = testServer.Host.Services.GetService(typeof(IPipelineStepStepRequirementService)) as IPipelineStepStepRequirementService;
			ApiPipelineStepStepRequirementServerResponseModel model = await service.Get(1);

			ApiPipelineStepStepRequirementClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 1, true);

			UpdateResponse<ApiPipelineStepStepRequirementClientResponseModel> updateResponse = await client.PipelineStepStepRequirementUpdateAsync(model.Id, request);

			context.Entry(context.Set<PipelineStepStepRequirement>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PipelineStepStepRequirement>().ToList()[0].Details.Should().Be("B");
			context.Set<PipelineStepStepRequirement>().ToList()[0].PipelineStepId.Should().Be(1);
			context.Set<PipelineStepStepRequirement>().ToList()[0].RequirementMet.Should().Be(true);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Details.Should().Be("B");
			updateResponse.Record.PipelineStepId.Should().Be(1);
			updateResponse.Record.RequirementMet.Should().Be(true);
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

			IPipelineStepStepRequirementService service = testServer.Host.Services.GetService(typeof(IPipelineStepStepRequirementService)) as IPipelineStepStepRequirementService;
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			model.SetProperties("B", 1, true);
			CreateResponse<ApiPipelineStepStepRequirementServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PipelineStepStepRequirementDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPipelineStepStepRequirementServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPipelineStepStepRequirementClientResponseModel response = await client.PipelineStepStepRequirementGetAsync(1);

			response.Should().NotBeNull();
			response.Details.Should().Be("A");
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
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
			ApiPipelineStepStepRequirementClientResponseModel response = await client.PipelineStepStepRequirementGetAsync(default(int));

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
			List<ApiPipelineStepStepRequirementClientResponseModel> response = await client.PipelineStepStepRequirementAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Details.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].PipelineStepId.Should().Be(1);
			response[0].RequirementMet.Should().Be(true);
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
				var result = await client.PipelineStepStepRequirementAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>b2732b6037e5194e6880a3857f970cba</Hash>
</Codenesium>*/