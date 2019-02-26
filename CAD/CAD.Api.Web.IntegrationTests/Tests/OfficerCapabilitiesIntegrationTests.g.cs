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
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "Integration")]
	public partial class OfficerCapabilitiesIntegrationTests
	{
		public OfficerCapabilitiesIntegrationTests()
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

			var model = new ApiOfficerCapabilitiesClientRequestModel();
			model.SetProperties(1);
			var model2 = new ApiOfficerCapabilitiesClientRequestModel();
			model2.SetProperties(1);
			var request = new List<ApiOfficerCapabilitiesClientRequestModel>() {model, model2};
			CreateResponse<List<ApiOfficerCapabilitiesClientResponseModel>> result = await client.OfficerCapabilitiesBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<OfficerCapabilities>().ToList()[1].OfficerId.Should().Be(1);

			context.Set<OfficerCapabilities>().ToList()[2].OfficerId.Should().Be(1);
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

			var model = new ApiOfficerCapabilitiesClientRequestModel();
			model.SetProperties(1);
			CreateResponse<ApiOfficerCapabilitiesClientResponseModel> result = await client.OfficerCapabilitiesCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<OfficerCapabilities>().ToList()[1].OfficerId.Should().Be(1);

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
			var mapper = new ApiOfficerCapabilitiesServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IOfficerCapabilitiesService service = testServer.Host.Services.GetService(typeof(IOfficerCapabilitiesService)) as IOfficerCapabilitiesService;
			ApiOfficerCapabilitiesServerResponseModel model = await service.Get(1);

			ApiOfficerCapabilitiesClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1);

			UpdateResponse<ApiOfficerCapabilitiesClientResponseModel> updateResponse = await client.OfficerCapabilitiesUpdateAsync(model.CapabilityId, request);

			context.Entry(context.Set<OfficerCapabilities>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.CapabilityId.Should().Be(1);
			context.Set<OfficerCapabilities>().ToList()[0].OfficerId.Should().Be(1);

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

			IOfficerCapabilitiesService service = testServer.Host.Services.GetService(typeof(IOfficerCapabilitiesService)) as IOfficerCapabilitiesService;
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			model.SetProperties(1);
			CreateResponse<ApiOfficerCapabilitiesServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.OfficerCapabilitiesDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiOfficerCapabilitiesServerResponseModel verifyResponse = await service.Get(2);

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

			ApiOfficerCapabilitiesClientResponseModel response = await client.OfficerCapabilitiesGetAsync(1);

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
			ApiOfficerCapabilitiesClientResponseModel response = await client.OfficerCapabilitiesGetAsync(default(int));

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

			List<ApiOfficerCapabilitiesClientResponseModel> response = await client.OfficerCapabilitiesAllAsync();

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
				var result = await client.OfficerCapabilitiesAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>79d2bf342920199e95015edd618c5f92</Hash>
</Codenesium>*/