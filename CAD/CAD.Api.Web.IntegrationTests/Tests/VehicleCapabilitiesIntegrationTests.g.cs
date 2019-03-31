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
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "Integration")]
	public partial class VehicleCapabilitiesIntegrationTests
	{
		public VehicleCapabilitiesIntegrationTests()
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

			var model = new ApiVehicleCapabilitiesClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiVehicleCapabilitiesClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiVehicleCapabilitiesClientRequestModel>() {model, model2};
			CreateResponse<List<ApiVehicleCapabilitiesClientResponseModel>> result = await client.VehicleCapabilitiesBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<VehicleCapabilities>().ToList()[1].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleCapabilities>().ToList()[1].VehicleId.Should().Be(1);

			context.Set<VehicleCapabilities>().ToList()[2].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleCapabilities>().ToList()[2].VehicleId.Should().Be(1);
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

			var model = new ApiVehicleCapabilitiesClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiVehicleCapabilitiesClientResponseModel> result = await client.VehicleCapabilitiesCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<VehicleCapabilities>().ToList()[1].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleCapabilities>().ToList()[1].VehicleId.Should().Be(1);

			result.Record.VehicleCapabilityId.Should().Be(1);
			result.Record.VehicleId.Should().Be(1);
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
			var mapper = new ApiVehicleCapabilitiesServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IVehicleCapabilitiesService service = testServer.Host.Services.GetService(typeof(IVehicleCapabilitiesService)) as IVehicleCapabilitiesService;
			ApiVehicleCapabilitiesServerResponseModel model = await service.Get(1);

			ApiVehicleCapabilitiesClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiVehicleCapabilitiesClientResponseModel> updateResponse = await client.VehicleCapabilitiesUpdateAsync(model.Id, request);

			context.Entry(context.Set<VehicleCapabilities>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<VehicleCapabilities>().ToList()[0].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleCapabilities>().ToList()[0].VehicleId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.VehicleCapabilityId.Should().Be(1);
			updateResponse.Record.VehicleId.Should().Be(1);
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

			IVehicleCapabilitiesService service = testServer.Host.Services.GetService(typeof(IVehicleCapabilitiesService)) as IVehicleCapabilitiesService;
			var model = new ApiVehicleCapabilitiesServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiVehicleCapabilitiesServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.VehicleCapabilitiesDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiVehicleCapabilitiesServerResponseModel verifyResponse = await service.Get(2);

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

			ApiVehicleCapabilitiesClientResponseModel response = await client.VehicleCapabilitiesGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiVehicleCapabilitiesClientResponseModel response = await client.VehicleCapabilitiesGetAsync(default(int));

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
			List<ApiVehicleCapabilitiesClientResponseModel> response = await client.VehicleCapabilitiesAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
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
				var result = await client.VehicleCapabilitiesAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>536802c087595b42bf8f290d3c83c694</Hash>
</Codenesium>*/