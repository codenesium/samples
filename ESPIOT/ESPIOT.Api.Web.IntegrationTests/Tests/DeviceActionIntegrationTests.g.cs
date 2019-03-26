using ESPIOTNS.Api.Client;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
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

namespace ESPIOTNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "Integration")]
	public partial class DeviceActionIntegrationTests
	{
		public DeviceActionIntegrationTests()
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

			var model = new ApiDeviceActionClientRequestModel();
			model.SetProperties("B", 1, "B");
			var model2 = new ApiDeviceActionClientRequestModel();
			model2.SetProperties("C", 1, "C");
			var request = new List<ApiDeviceActionClientRequestModel>() {model, model2};
			CreateResponse<List<ApiDeviceActionClientResponseModel>> result = await client.DeviceActionBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<DeviceAction>().ToList()[1].Action.Should().Be("B");
			context.Set<DeviceAction>().ToList()[1].DeviceId.Should().Be(1);
			context.Set<DeviceAction>().ToList()[1].Name.Should().Be("B");

			context.Set<DeviceAction>().ToList()[2].Action.Should().Be("C");
			context.Set<DeviceAction>().ToList()[2].DeviceId.Should().Be(1);
			context.Set<DeviceAction>().ToList()[2].Name.Should().Be("C");
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

			var model = new ApiDeviceActionClientRequestModel();
			model.SetProperties("B", 1, "B");
			CreateResponse<ApiDeviceActionClientResponseModel> result = await client.DeviceActionCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<DeviceAction>().ToList()[1].Action.Should().Be("B");
			context.Set<DeviceAction>().ToList()[1].DeviceId.Should().Be(1);
			context.Set<DeviceAction>().ToList()[1].Name.Should().Be("B");

			result.Record.Action.Should().Be("B");
			result.Record.DeviceId.Should().Be(1);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiDeviceActionServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IDeviceActionService service = testServer.Host.Services.GetService(typeof(IDeviceActionService)) as IDeviceActionService;
			ApiDeviceActionServerResponseModel model = await service.Get(1);

			ApiDeviceActionClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 1, "B");

			UpdateResponse<ApiDeviceActionClientResponseModel> updateResponse = await client.DeviceActionUpdateAsync(model.Id, request);

			context.Entry(context.Set<DeviceAction>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<DeviceAction>().ToList()[0].Action.Should().Be("B");
			context.Set<DeviceAction>().ToList()[0].DeviceId.Should().Be(1);
			context.Set<DeviceAction>().ToList()[0].Name.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Action.Should().Be("B");
			updateResponse.Record.DeviceId.Should().Be(1);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IDeviceActionService service = testServer.Host.Services.GetService(typeof(IDeviceActionService)) as IDeviceActionService;
			var model = new ApiDeviceActionServerRequestModel();
			model.SetProperties("B", 1, "B");
			CreateResponse<ApiDeviceActionServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.DeviceActionDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiDeviceActionServerResponseModel verifyResponse = await service.Get(2);

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

			ApiDeviceActionClientResponseModel response = await client.DeviceActionGetAsync(1);

			response.Should().NotBeNull();
			response.Action.Should().Be("A");
			response.DeviceId.Should().Be(1);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiDeviceActionClientResponseModel response = await client.DeviceActionGetAsync(default(int));

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
			List<ApiDeviceActionClientResponseModel> response = await client.DeviceActionAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Action.Should().Be("A");
			response[0].DeviceId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByDeviceIdFound()
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
			List<ApiDeviceActionClientResponseModel> response = await client.ByDeviceActionByDeviceId(1);

			response.Should().NotBeEmpty();
			response[0].Action.Should().Be("A");
			response[0].DeviceId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByDeviceIdNotFound()
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
			List<ApiDeviceActionClientResponseModel> response = await client.ByDeviceActionByDeviceId(default(int));

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
				var result = await client.DeviceActionAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>9ca1b26fef0d24654d48883e68bcdc36</Hash>
</Codenesium>*/