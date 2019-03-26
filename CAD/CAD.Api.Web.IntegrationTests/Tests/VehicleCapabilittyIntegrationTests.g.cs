using CADNS.Api.Client;
using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using CADNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CADNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "Integration")]
	public partial class VehicleCapabilittyIntegrationTests
	{
		public VehicleCapabilittyIntegrationTests()
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

			var model = new ApiVehicleCapabilittyClientRequestModel();
			model.SetProperties(1);
			var model2 = new ApiVehicleCapabilittyClientRequestModel();
			model2.SetProperties(1);
			var request = new List<ApiVehicleCapabilittyClientRequestModel>() {model, model2};
			CreateResponse<List<ApiVehicleCapabilittyClientResponseModel>> result = await client.VehicleCapabilittyBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<VehicleCapabilitty>().ToList()[1].VehicleCapabilityId.Should().Be(1);

			context.Set<VehicleCapabilitty>().ToList()[2].VehicleCapabilityId.Should().Be(1);
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

			var model = new ApiVehicleCapabilittyClientRequestModel();
			model.SetProperties(1);
			CreateResponse<ApiVehicleCapabilittyClientResponseModel> result = await client.VehicleCapabilittyCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<VehicleCapabilitty>().ToList()[1].VehicleCapabilityId.Should().Be(1);

			result.Record.VehicleCapabilityId.Should().Be(1);
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
			var mapper = new ApiVehicleCapabilittyServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IVehicleCapabilittyService service = testServer.Host.Services.GetService(typeof(IVehicleCapabilittyService)) as IVehicleCapabilittyService;
			ApiVehicleCapabilittyServerResponseModel model = await service.Get(1);

			ApiVehicleCapabilittyClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1);

			UpdateResponse<ApiVehicleCapabilittyClientResponseModel> updateResponse = await client.VehicleCapabilittyUpdateAsync(model.VehicleId, request);

			context.Entry(context.Set<VehicleCapabilitty>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.VehicleId.Should().Be(1);
			context.Set<VehicleCapabilitty>().ToList()[0].VehicleCapabilityId.Should().Be(1);

			updateResponse.Record.VehicleId.Should().Be(1);
			updateResponse.Record.VehicleCapabilityId.Should().Be(1);
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

			IVehicleCapabilittyService service = testServer.Host.Services.GetService(typeof(IVehicleCapabilittyService)) as IVehicleCapabilittyService;
			var model = new ApiVehicleCapabilittyServerRequestModel();
			model.SetProperties(1);
			CreateResponse<ApiVehicleCapabilittyServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.VehicleCapabilittyDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiVehicleCapabilittyServerResponseModel verifyResponse = await service.Get(2);

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

			ApiVehicleCapabilittyClientResponseModel response = await client.VehicleCapabilittyGetAsync(1);

			response.Should().NotBeNull();
			response.VehicleCapabilityId.Should().Be(1);
			response.VehicleId.Should().Be(1);
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
			ApiVehicleCapabilittyClientResponseModel response = await client.VehicleCapabilittyGetAsync(default(int));

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
			List<ApiVehicleCapabilittyClientResponseModel> response = await client.VehicleCapabilittyAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].VehicleCapabilityId.Should().Be(1);
			response[0].VehicleId.Should().Be(1);
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
				var result = await client.VehicleCapabilittyAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>5076d7bb15ca8d215c943c52dbfa8040</Hash>
</Codenesium>*/