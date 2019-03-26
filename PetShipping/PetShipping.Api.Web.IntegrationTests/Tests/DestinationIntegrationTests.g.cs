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
	[Trait("Table", "Destination")]
	[Trait("Area", "Integration")]
	public partial class DestinationIntegrationTests
	{
		public DestinationIntegrationTests()
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

			var model = new ApiDestinationClientRequestModel();
			model.SetProperties(1, "B", 2);
			var model2 = new ApiDestinationClientRequestModel();
			model2.SetProperties(1, "C", 3);
			var request = new List<ApiDestinationClientRequestModel>() {model, model2};
			CreateResponse<List<ApiDestinationClientResponseModel>> result = await client.DestinationBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Destination>().ToList()[1].CountryId.Should().Be(1);
			context.Set<Destination>().ToList()[1].Name.Should().Be("B");
			context.Set<Destination>().ToList()[1].Order.Should().Be(2);

			context.Set<Destination>().ToList()[2].CountryId.Should().Be(1);
			context.Set<Destination>().ToList()[2].Name.Should().Be("C");
			context.Set<Destination>().ToList()[2].Order.Should().Be(3);
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

			var model = new ApiDestinationClientRequestModel();
			model.SetProperties(1, "B", 2);
			CreateResponse<ApiDestinationClientResponseModel> result = await client.DestinationCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Destination>().ToList()[1].CountryId.Should().Be(1);
			context.Set<Destination>().ToList()[1].Name.Should().Be("B");
			context.Set<Destination>().ToList()[1].Order.Should().Be(2);

			result.Record.CountryId.Should().Be(1);
			result.Record.Name.Should().Be("B");
			result.Record.Order.Should().Be(2);
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
			var mapper = new ApiDestinationServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IDestinationService service = testServer.Host.Services.GetService(typeof(IDestinationService)) as IDestinationService;
			ApiDestinationServerResponseModel model = await service.Get(1);

			ApiDestinationClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, "B", 2);

			UpdateResponse<ApiDestinationClientResponseModel> updateResponse = await client.DestinationUpdateAsync(model.Id, request);

			context.Entry(context.Set<Destination>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Destination>().ToList()[0].CountryId.Should().Be(1);
			context.Set<Destination>().ToList()[0].Name.Should().Be("B");
			context.Set<Destination>().ToList()[0].Order.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CountryId.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Order.Should().Be(2);
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

			IDestinationService service = testServer.Host.Services.GetService(typeof(IDestinationService)) as IDestinationService;
			var model = new ApiDestinationServerRequestModel();
			model.SetProperties(1, "B", 2);
			CreateResponse<ApiDestinationServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.DestinationDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiDestinationServerResponseModel verifyResponse = await service.Get(2);

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

			ApiDestinationClientResponseModel response = await client.DestinationGetAsync(1);

			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
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
			ApiDestinationClientResponseModel response = await client.DestinationGetAsync(default(int));

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
			List<ApiDestinationClientResponseModel> response = await client.DestinationAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CountryId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Order.Should().Be(1);
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepDestinationsByDestinationIdFound()
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
			List<ApiPipelineStepDestinationClientResponseModel> response = await client.PipelineStepDestinationsByDestinationId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepDestinationsByDestinationIdNotFound()
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
			List<ApiPipelineStepDestinationClientResponseModel> response = await client.PipelineStepDestinationsByDestinationId(default(int));

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
				var result = await client.DestinationAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>8922a7aa666414194d253ea25bfee467</Hash>
</Codenesium>*/