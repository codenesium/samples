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
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "Integration")]
	public partial class OfficerCapabilityIntegrationTests
	{
		public OfficerCapabilityIntegrationTests()
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

			var model = new ApiOfficerCapabilityClientRequestModel();
			model.SetProperties(1);
			var model2 = new ApiOfficerCapabilityClientRequestModel();
			model2.SetProperties(1);
			var request = new List<ApiOfficerCapabilityClientRequestModel>() {model, model2};
			CreateResponse<List<ApiOfficerCapabilityClientResponseModel>> result = await client.OfficerCapabilityBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<OfficerCapability>().ToList()[1].OfficerId.Should().Be(1);

			context.Set<OfficerCapability>().ToList()[2].OfficerId.Should().Be(1);
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

			var model = new ApiOfficerCapabilityClientRequestModel();
			model.SetProperties(1);
			CreateResponse<ApiOfficerCapabilityClientResponseModel> result = await client.OfficerCapabilityCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<OfficerCapability>().ToList()[1].OfficerId.Should().Be(1);

			result.Record.OfficerId.Should().Be(1);
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
			var mapper = new ApiOfficerCapabilityServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IOfficerCapabilityService service = testServer.Host.Services.GetService(typeof(IOfficerCapabilityService)) as IOfficerCapabilityService;
			ApiOfficerCapabilityServerResponseModel model = await service.Get(1);

			ApiOfficerCapabilityClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1);

			UpdateResponse<ApiOfficerCapabilityClientResponseModel> updateResponse = await client.OfficerCapabilityUpdateAsync(model.CapabilityId, request);

			context.Entry(context.Set<OfficerCapability>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.CapabilityId.Should().Be(1);
			context.Set<OfficerCapability>().ToList()[0].OfficerId.Should().Be(1);

			updateResponse.Record.CapabilityId.Should().Be(1);
			updateResponse.Record.OfficerId.Should().Be(1);
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

			IOfficerCapabilityService service = testServer.Host.Services.GetService(typeof(IOfficerCapabilityService)) as IOfficerCapabilityService;
			var model = new ApiOfficerCapabilityServerRequestModel();
			model.SetProperties(1);
			CreateResponse<ApiOfficerCapabilityServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.OfficerCapabilityDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiOfficerCapabilityServerResponseModel verifyResponse = await service.Get(2);

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

			ApiOfficerCapabilityClientResponseModel response = await client.OfficerCapabilityGetAsync(1);

			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
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
			ApiOfficerCapabilityClientResponseModel response = await client.OfficerCapabilityGetAsync(default(int));

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
			List<ApiOfficerCapabilityClientResponseModel> response = await client.OfficerCapabilityAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CapabilityId.Should().Be(1);
			response[0].OfficerId.Should().Be(1);
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
				var result = await client.OfficerCapabilityAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>ef51ac9d035c338bbaa65475ac547c82</Hash>
</Codenesium>*/