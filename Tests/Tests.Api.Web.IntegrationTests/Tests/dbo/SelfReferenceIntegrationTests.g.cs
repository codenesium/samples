using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "Integration")]
	public partial class SelfReferenceIntegrationTests
	{
		public SelfReferenceIntegrationTests()
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

			var model = new ApiSelfReferenceClientRequestModel();
			model.SetProperties(2, 2);
			var model2 = new ApiSelfReferenceClientRequestModel();
			model2.SetProperties(3, 3);
			var request = new List<ApiSelfReferenceClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSelfReferenceClientResponseModel>> result = await client.SelfReferenceBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SelfReference>().ToList()[1].SelfReferenceId.Should().Be(2);
			context.Set<SelfReference>().ToList()[1].SelfReferenceId2.Should().Be(2);

			context.Set<SelfReference>().ToList()[2].SelfReferenceId.Should().Be(3);
			context.Set<SelfReference>().ToList()[2].SelfReferenceId2.Should().Be(3);
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

			var model = new ApiSelfReferenceClientRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiSelfReferenceClientResponseModel> result = await client.SelfReferenceCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SelfReference>().ToList()[1].SelfReferenceId.Should().Be(2);
			context.Set<SelfReference>().ToList()[1].SelfReferenceId2.Should().Be(2);

			result.Record.SelfReferenceId.Should().Be(2);
			result.Record.SelfReferenceId2.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiSelfReferenceServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISelfReferenceService service = testServer.Host.Services.GetService(typeof(ISelfReferenceService)) as ISelfReferenceService;
			ApiSelfReferenceServerResponseModel model = await service.Get(1);

			ApiSelfReferenceClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 2);

			UpdateResponse<ApiSelfReferenceClientResponseModel> updateResponse = await client.SelfReferenceUpdateAsync(model.Id, request);

			context.Entry(context.Set<SelfReference>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<SelfReference>().ToList()[0].SelfReferenceId.Should().Be(2);
			context.Set<SelfReference>().ToList()[0].SelfReferenceId2.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.SelfReferenceId.Should().Be(2);
			updateResponse.Record.SelfReferenceId2.Should().Be(2);
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

			ISelfReferenceService service = testServer.Host.Services.GetService(typeof(ISelfReferenceService)) as ISelfReferenceService;
			var model = new ApiSelfReferenceServerRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiSelfReferenceServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SelfReferenceDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSelfReferenceServerResponseModel verifyResponse = await service.Get(2);

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

			ApiSelfReferenceClientResponseModel response = await client.SelfReferenceGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSelfReferenceClientResponseModel response = await client.SelfReferenceGetAsync(default(int));

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

			List<ApiSelfReferenceClientResponseModel> response = await client.SelfReferenceAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].SelfReferenceId.Should().Be(1);
			response[0].SelfReferenceId2.Should().Be(1);
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
				var result = await client.SelfReferenceAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>4551adb416764a1cd0de28b4a5f0de63</Hash>
</Codenesium>*/