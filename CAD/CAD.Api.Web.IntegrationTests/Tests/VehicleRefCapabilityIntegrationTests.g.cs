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
	[Trait("Table", "VehicleRefCapability")]
	[Trait("Area", "Integration")]
	public partial class VehicleRefCapabilityIntegrationTests
	{
		public VehicleRefCapabilityIntegrationTests()
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

			var model = new ApiVehicleRefCapabilityClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiVehicleRefCapabilityClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiVehicleRefCapabilityClientRequestModel>() {model, model2};
			CreateResponse<List<ApiVehicleRefCapabilityClientResponseModel>> result = await client.VehicleRefCapabilityBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<VehicleRefCapability>().ToList()[1].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleRefCapability>().ToList()[1].VehicleId.Should().Be(1);

			context.Set<VehicleRefCapability>().ToList()[2].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleRefCapability>().ToList()[2].VehicleId.Should().Be(1);
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

			var model = new ApiVehicleRefCapabilityClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiVehicleRefCapabilityClientResponseModel> result = await client.VehicleRefCapabilityCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<VehicleRefCapability>().ToList()[1].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleRefCapability>().ToList()[1].VehicleId.Should().Be(1);

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
			var mapper = new ApiVehicleRefCapabilityServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IVehicleRefCapabilityService service = testServer.Host.Services.GetService(typeof(IVehicleRefCapabilityService)) as IVehicleRefCapabilityService;
			ApiVehicleRefCapabilityServerResponseModel model = await service.Get(1);

			ApiVehicleRefCapabilityClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiVehicleRefCapabilityClientResponseModel> updateResponse = await client.VehicleRefCapabilityUpdateAsync(model.Id, request);

			context.Entry(context.Set<VehicleRefCapability>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<VehicleRefCapability>().ToList()[0].VehicleCapabilityId.Should().Be(1);
			context.Set<VehicleRefCapability>().ToList()[0].VehicleId.Should().Be(1);

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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IVehicleRefCapabilityService service = testServer.Host.Services.GetService(typeof(IVehicleRefCapabilityService)) as IVehicleRefCapabilityService;
			var model = new ApiVehicleRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiVehicleRefCapabilityServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.VehicleRefCapabilityDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiVehicleRefCapabilityServerResponseModel verifyResponse = await service.Get(2);

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

			ApiVehicleRefCapabilityClientResponseModel response = await client.VehicleRefCapabilityGetAsync(1);

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
			ApiVehicleRefCapabilityClientResponseModel response = await client.VehicleRefCapabilityGetAsync(default(int));

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

			List<ApiVehicleRefCapabilityClientResponseModel> response = await client.VehicleRefCapabilityAllAsync();

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
				var result = await client.VehicleRefCapabilityAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>1c7b450dbf9e4125f983aec6b5bdd2a5</Hash>
</Codenesium>*/