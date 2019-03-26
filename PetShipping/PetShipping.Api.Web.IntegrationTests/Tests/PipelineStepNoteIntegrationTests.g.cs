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
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "Integration")]
	public partial class PipelineStepNoteIntegrationTests
	{
		public PipelineStepNoteIntegrationTests()
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

			var model = new ApiPipelineStepNoteClientRequestModel();
			model.SetProperties(1, "B", 1);
			var model2 = new ApiPipelineStepNoteClientRequestModel();
			model2.SetProperties(1, "C", 1);
			var request = new List<ApiPipelineStepNoteClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPipelineStepNoteClientResponseModel>> result = await client.PipelineStepNoteBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PipelineStepNote>().ToList()[1].EmployeeId.Should().Be(1);
			context.Set<PipelineStepNote>().ToList()[1].Note.Should().Be("B");
			context.Set<PipelineStepNote>().ToList()[1].PipelineStepId.Should().Be(1);

			context.Set<PipelineStepNote>().ToList()[2].EmployeeId.Should().Be(1);
			context.Set<PipelineStepNote>().ToList()[2].Note.Should().Be("C");
			context.Set<PipelineStepNote>().ToList()[2].PipelineStepId.Should().Be(1);
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

			var model = new ApiPipelineStepNoteClientRequestModel();
			model.SetProperties(1, "B", 1);
			CreateResponse<ApiPipelineStepNoteClientResponseModel> result = await client.PipelineStepNoteCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PipelineStepNote>().ToList()[1].EmployeeId.Should().Be(1);
			context.Set<PipelineStepNote>().ToList()[1].Note.Should().Be("B");
			context.Set<PipelineStepNote>().ToList()[1].PipelineStepId.Should().Be(1);

			result.Record.EmployeeId.Should().Be(1);
			result.Record.Note.Should().Be("B");
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiPipelineStepNoteServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPipelineStepNoteService service = testServer.Host.Services.GetService(typeof(IPipelineStepNoteService)) as IPipelineStepNoteService;
			ApiPipelineStepNoteServerResponseModel model = await service.Get(1);

			ApiPipelineStepNoteClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, "B", 1);

			UpdateResponse<ApiPipelineStepNoteClientResponseModel> updateResponse = await client.PipelineStepNoteUpdateAsync(model.Id, request);

			context.Entry(context.Set<PipelineStepNote>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PipelineStepNote>().ToList()[0].EmployeeId.Should().Be(1);
			context.Set<PipelineStepNote>().ToList()[0].Note.Should().Be("B");
			context.Set<PipelineStepNote>().ToList()[0].PipelineStepId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.EmployeeId.Should().Be(1);
			updateResponse.Record.Note.Should().Be("B");
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IPipelineStepNoteService service = testServer.Host.Services.GetService(typeof(IPipelineStepNoteService)) as IPipelineStepNoteService;
			var model = new ApiPipelineStepNoteServerRequestModel();
			model.SetProperties(1, "B", 1);
			CreateResponse<ApiPipelineStepNoteServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PipelineStepNoteDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPipelineStepNoteServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPipelineStepNoteClientResponseModel response = await client.PipelineStepNoteGetAsync(1);

			response.Should().NotBeNull();
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiPipelineStepNoteClientResponseModel response = await client.PipelineStepNoteGetAsync(default(int));

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
			List<ApiPipelineStepNoteClientResponseModel> response = await client.PipelineStepNoteAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].EmployeeId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Note.Should().Be("A");
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
				var result = await client.PipelineStepNoteAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>77dcfe1d394b4e0e9ef37d079d232761</Hash>
</Codenesium>*/