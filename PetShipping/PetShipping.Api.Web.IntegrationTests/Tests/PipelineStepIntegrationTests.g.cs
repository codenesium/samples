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
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "Integration")]
	public partial class PipelineStepIntegrationTests
	{
		public PipelineStepIntegrationTests()
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

			var model = new ApiPipelineStepClientRequestModel();
			model.SetProperties("B", 1, 1);
			var model2 = new ApiPipelineStepClientRequestModel();
			model2.SetProperties("C", 1, 1);
			var request = new List<ApiPipelineStepClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPipelineStepClientResponseModel>> result = await client.PipelineStepBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PipelineStep>().ToList()[1].Name.Should().Be("B");
			context.Set<PipelineStep>().ToList()[1].PipelineStepStatusId.Should().Be(1);
			context.Set<PipelineStep>().ToList()[1].ShipperId.Should().Be(1);

			context.Set<PipelineStep>().ToList()[2].Name.Should().Be("C");
			context.Set<PipelineStep>().ToList()[2].PipelineStepStatusId.Should().Be(1);
			context.Set<PipelineStep>().ToList()[2].ShipperId.Should().Be(1);
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

			var model = new ApiPipelineStepClientRequestModel();
			model.SetProperties("B", 1, 1);
			CreateResponse<ApiPipelineStepClientResponseModel> result = await client.PipelineStepCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PipelineStep>().ToList()[1].Name.Should().Be("B");
			context.Set<PipelineStep>().ToList()[1].PipelineStepStatusId.Should().Be(1);
			context.Set<PipelineStep>().ToList()[1].ShipperId.Should().Be(1);

			result.Record.Name.Should().Be("B");
			result.Record.PipelineStepStatusId.Should().Be(1);
			result.Record.ShipperId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiPipelineStepServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPipelineStepService service = testServer.Host.Services.GetService(typeof(IPipelineStepService)) as IPipelineStepService;
			ApiPipelineStepServerResponseModel model = await service.Get(1);

			ApiPipelineStepClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 1, 1);

			UpdateResponse<ApiPipelineStepClientResponseModel> updateResponse = await client.PipelineStepUpdateAsync(model.Id, request);

			context.Entry(context.Set<PipelineStep>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PipelineStep>().ToList()[0].Name.Should().Be("B");
			context.Set<PipelineStep>().ToList()[0].PipelineStepStatusId.Should().Be(1);
			context.Set<PipelineStep>().ToList()[0].ShipperId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.PipelineStepStatusId.Should().Be(1);
			updateResponse.Record.ShipperId.Should().Be(1);
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

			IPipelineStepService service = testServer.Host.Services.GetService(typeof(IPipelineStepService)) as IPipelineStepService;
			var model = new ApiPipelineStepServerRequestModel();
			model.SetProperties("B", 1, 1);
			CreateResponse<ApiPipelineStepServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PipelineStepDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPipelineStepServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPipelineStepClientResponseModel response = await client.PipelineStepGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPipelineStepClientResponseModel response = await client.PipelineStepGetAsync(default(int));

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

			List<ApiPipelineStepClientResponseModel> response = await client.PipelineStepAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].PipelineStepStatusId.Should().Be(1);
			response[0].ShipperId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestForeignKeyHandlerPipelineStepsByPipelineStepIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiHandlerPipelineStepClientResponseModel> response = await client.HandlerPipelineStepsByPipelineStepId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyHandlerPipelineStepsByPipelineStepIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiHandlerPipelineStepClientResponseModel> response = await client.HandlerPipelineStepsByPipelineStepId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyOtherTransportsByPipelineStepIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiOtherTransportClientResponseModel> response = await client.OtherTransportsByPipelineStepId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyOtherTransportsByPipelineStepIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiOtherTransportClientResponseModel> response = await client.OtherTransportsByPipelineStepId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepDestinationsByPipelineStepIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepDestinationClientResponseModel> response = await client.PipelineStepDestinationsByPipelineStepId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepDestinationsByPipelineStepIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepDestinationClientResponseModel> response = await client.PipelineStepDestinationsByPipelineStepId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepNotesByPipelineStepIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepNoteClientResponseModel> response = await client.PipelineStepNotesByPipelineStepId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepNotesByPipelineStepIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepNoteClientResponseModel> response = await client.PipelineStepNotesByPipelineStepId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepStepRequirementsByPipelineStepIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepStepRequirementClientResponseModel> response = await client.PipelineStepStepRequirementsByPipelineStepId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepStepRequirementsByPipelineStepIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepStepRequirementClientResponseModel> response = await client.PipelineStepStepRequirementsByPipelineStepId(default(int));

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
				var result = await client.PipelineStepAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>1441589ea0d3cef57766ab4681e5e619</Hash>
</Codenesium>*/