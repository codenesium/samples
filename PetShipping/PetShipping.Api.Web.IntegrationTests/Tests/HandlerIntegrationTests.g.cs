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
	[Trait("Table", "Handler")]
	[Trait("Area", "Integration")]
	public partial class HandlerIntegrationTests
	{
		public HandlerIntegrationTests()
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

			var model = new ApiHandlerClientRequestModel();
			model.SetProperties(2, "B", "B", "B", "B");
			var model2 = new ApiHandlerClientRequestModel();
			model2.SetProperties(3, "C", "C", "C", "C");
			var request = new List<ApiHandlerClientRequestModel>() {model, model2};
			CreateResponse<List<ApiHandlerClientResponseModel>> result = await client.HandlerBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Handler>().ToList()[1].CountryId.Should().Be(2);
			context.Set<Handler>().ToList()[1].Email.Should().Be("B");
			context.Set<Handler>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Handler>().ToList()[1].LastName.Should().Be("B");
			context.Set<Handler>().ToList()[1].Phone.Should().Be("B");

			context.Set<Handler>().ToList()[2].CountryId.Should().Be(3);
			context.Set<Handler>().ToList()[2].Email.Should().Be("C");
			context.Set<Handler>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Handler>().ToList()[2].LastName.Should().Be("C");
			context.Set<Handler>().ToList()[2].Phone.Should().Be("C");
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

			var model = new ApiHandlerClientRequestModel();
			model.SetProperties(2, "B", "B", "B", "B");
			CreateResponse<ApiHandlerClientResponseModel> result = await client.HandlerCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Handler>().ToList()[1].CountryId.Should().Be(2);
			context.Set<Handler>().ToList()[1].Email.Should().Be("B");
			context.Set<Handler>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Handler>().ToList()[1].LastName.Should().Be("B");
			context.Set<Handler>().ToList()[1].Phone.Should().Be("B");

			result.Record.CountryId.Should().Be(2);
			result.Record.Email.Should().Be("B");
			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.Phone.Should().Be("B");
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
			var mapper = new ApiHandlerServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IHandlerService service = testServer.Host.Services.GetService(typeof(IHandlerService)) as IHandlerService;
			ApiHandlerServerResponseModel model = await service.Get(1);

			ApiHandlerClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, "B", "B", "B", "B");

			UpdateResponse<ApiHandlerClientResponseModel> updateResponse = await client.HandlerUpdateAsync(model.Id, request);

			context.Entry(context.Set<Handler>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Handler>().ToList()[0].CountryId.Should().Be(2);
			context.Set<Handler>().ToList()[0].Email.Should().Be("B");
			context.Set<Handler>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Handler>().ToList()[0].LastName.Should().Be("B");
			context.Set<Handler>().ToList()[0].Phone.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CountryId.Should().Be(2);
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.Phone.Should().Be("B");
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

			IHandlerService service = testServer.Host.Services.GetService(typeof(IHandlerService)) as IHandlerService;
			var model = new ApiHandlerServerRequestModel();
			model.SetProperties(2, "B", "B", "B", "B");
			CreateResponse<ApiHandlerServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.HandlerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiHandlerServerResponseModel verifyResponse = await service.Get(2);

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

			ApiHandlerClientResponseModel response = await client.HandlerGetAsync(1);

			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
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
			ApiHandlerClientResponseModel response = await client.HandlerGetAsync(default(int));

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
			List<ApiHandlerClientResponseModel> response = await client.HandlerAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CountryId.Should().Be(1);
			response[0].Email.Should().Be("A");
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastName.Should().Be("A");
			response[0].Phone.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyAirTransportsByHandlerIdFound()
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
			List<ApiAirTransportClientResponseModel> response = await client.AirTransportsByHandlerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyAirTransportsByHandlerIdNotFound()
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
			List<ApiAirTransportClientResponseModel> response = await client.AirTransportsByHandlerId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyHandlerPipelineStepsByHandlerIdFound()
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
			List<ApiHandlerPipelineStepClientResponseModel> response = await client.HandlerPipelineStepsByHandlerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyHandlerPipelineStepsByHandlerIdNotFound()
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
			List<ApiHandlerPipelineStepClientResponseModel> response = await client.HandlerPipelineStepsByHandlerId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyOtherTransportsByHandlerIdFound()
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
			List<ApiOtherTransportClientResponseModel> response = await client.OtherTransportsByHandlerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyOtherTransportsByHandlerIdNotFound()
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
			List<ApiOtherTransportClientResponseModel> response = await client.OtherTransportsByHandlerId(default(int));

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
				var result = await client.HandlerAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>7393313d937eb7430eea72e9c194c47c</Hash>
</Codenesium>*/