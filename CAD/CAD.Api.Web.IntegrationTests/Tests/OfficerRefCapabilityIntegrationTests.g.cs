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
	[Trait("Table", "OfficerRefCapability")]
	[Trait("Area", "Integration")]
	public partial class OfficerRefCapabilityIntegrationTests
	{
		public OfficerRefCapabilityIntegrationTests()
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

			var model = new ApiOfficerRefCapabilityClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiOfficerRefCapabilityClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiOfficerRefCapabilityClientRequestModel>() {model, model2};
			CreateResponse<List<ApiOfficerRefCapabilityClientResponseModel>> result = await client.OfficerRefCapabilityBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<OfficerRefCapability>().ToList()[1].CapabilityId.Should().Be(1);
			context.Set<OfficerRefCapability>().ToList()[1].OfficerId.Should().Be(1);

			context.Set<OfficerRefCapability>().ToList()[2].CapabilityId.Should().Be(1);
			context.Set<OfficerRefCapability>().ToList()[2].OfficerId.Should().Be(1);
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

			var model = new ApiOfficerRefCapabilityClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiOfficerRefCapabilityClientResponseModel> result = await client.OfficerRefCapabilityCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<OfficerRefCapability>().ToList()[1].CapabilityId.Should().Be(1);
			context.Set<OfficerRefCapability>().ToList()[1].OfficerId.Should().Be(1);

			result.Record.CapabilityId.Should().Be(1);
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
			var mapper = new ApiOfficerRefCapabilityServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IOfficerRefCapabilityService service = testServer.Host.Services.GetService(typeof(IOfficerRefCapabilityService)) as IOfficerRefCapabilityService;
			ApiOfficerRefCapabilityServerResponseModel model = await service.Get(1);

			ApiOfficerRefCapabilityClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiOfficerRefCapabilityClientResponseModel> updateResponse = await client.OfficerRefCapabilityUpdateAsync(model.Id, request);

			context.Entry(context.Set<OfficerRefCapability>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<OfficerRefCapability>().ToList()[0].CapabilityId.Should().Be(1);
			context.Set<OfficerRefCapability>().ToList()[0].OfficerId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IOfficerRefCapabilityService service = testServer.Host.Services.GetService(typeof(IOfficerRefCapabilityService)) as IOfficerRefCapabilityService;
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiOfficerRefCapabilityServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.OfficerRefCapabilityDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiOfficerRefCapabilityServerResponseModel verifyResponse = await service.Get(2);

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

			ApiOfficerRefCapabilityClientResponseModel response = await client.OfficerRefCapabilityGetAsync(1);

			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.Id.Should().Be(1);
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
			ApiOfficerRefCapabilityClientResponseModel response = await client.OfficerRefCapabilityGetAsync(default(int));

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

			List<ApiOfficerRefCapabilityClientResponseModel> response = await client.OfficerRefCapabilityAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CapabilityId.Should().Be(1);
			response[0].Id.Should().Be(1);
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
				var result = await client.OfficerRefCapabilityAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>18affe183eea440f20acc004539a3671</Hash>
</Codenesium>*/