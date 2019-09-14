using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Integration")]
	public partial class SpaceSpaceFeatureIntegrationTests
	{
		public SpaceSpaceFeatureIntegrationTests()
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

			var model = new ApiSpaceSpaceFeatureClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiSpaceSpaceFeatureClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiSpaceSpaceFeatureClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSpaceSpaceFeatureClientResponseModel>> result = await client.SpaceSpaceFeatureBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SpaceSpaceFeature>().ToList()[1].SpaceFeatureId.Should().Be(1);
			context.Set<SpaceSpaceFeature>().ToList()[1].SpaceId.Should().Be(1);

			context.Set<SpaceSpaceFeature>().ToList()[2].SpaceFeatureId.Should().Be(1);
			context.Set<SpaceSpaceFeature>().ToList()[2].SpaceId.Should().Be(1);
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

			var model = new ApiSpaceSpaceFeatureClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSpaceSpaceFeatureClientResponseModel> result = await client.SpaceSpaceFeatureCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SpaceSpaceFeature>().ToList()[1].SpaceFeatureId.Should().Be(1);
			context.Set<SpaceSpaceFeature>().ToList()[1].SpaceId.Should().Be(1);

			result.Record.SpaceFeatureId.Should().Be(1);
			result.Record.SpaceId.Should().Be(1);
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
			var mapper = new ApiSpaceSpaceFeatureServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISpaceSpaceFeatureService service = testServer.Host.Services.GetService(typeof(ISpaceSpaceFeatureService)) as ISpaceSpaceFeatureService;
			ApiSpaceSpaceFeatureServerResponseModel model = await service.Get(1);

			ApiSpaceSpaceFeatureClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiSpaceSpaceFeatureClientResponseModel> updateResponse = await client.SpaceSpaceFeatureUpdateAsync(model.Id, request);

			context.Entry(context.Set<SpaceSpaceFeature>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<SpaceSpaceFeature>().ToList()[0].SpaceFeatureId.Should().Be(1);
			context.Set<SpaceSpaceFeature>().ToList()[0].SpaceId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.SpaceFeatureId.Should().Be(1);
			updateResponse.Record.SpaceId.Should().Be(1);
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

			ISpaceSpaceFeatureService service = testServer.Host.Services.GetService(typeof(ISpaceSpaceFeatureService)) as ISpaceSpaceFeatureService;
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSpaceSpaceFeatureServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SpaceSpaceFeatureDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSpaceSpaceFeatureServerResponseModel verifyResponse = await service.Get(2);

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

			ApiSpaceSpaceFeatureClientResponseModel response = await client.SpaceSpaceFeatureGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
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
			ApiSpaceSpaceFeatureClientResponseModel response = await client.SpaceSpaceFeatureGetAsync(default(int));

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
			List<ApiSpaceSpaceFeatureClientResponseModel> response = await client.SpaceSpaceFeatureAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].SpaceFeatureId.Should().Be(1);
			response[0].SpaceId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySpaceFeatureIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSpaceSpaceFeatureClientResponseModel> response = await client.BySpaceSpaceFeatureBySpaceFeatureId(1);

			response.Should().NotBeEmpty();
			response[0].Id.Should().Be(1);
			response[0].SpaceFeatureId.Should().Be(1);
			response[0].SpaceId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySpaceFeatureIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSpaceSpaceFeatureClientResponseModel> response = await client.BySpaceSpaceFeatureBySpaceFeatureId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestBySpaceIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSpaceSpaceFeatureClientResponseModel> response = await client.BySpaceSpaceFeatureBySpaceId(1);

			response.Should().NotBeEmpty();
			response[0].Id.Should().Be(1);
			response[0].SpaceFeatureId.Should().Be(1);
			response[0].SpaceId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySpaceIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSpaceSpaceFeatureClientResponseModel> response = await client.BySpaceSpaceFeatureBySpaceId(default(int));

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
				var result = await client.SpaceSpaceFeatureAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>aedbb3c9cf9f153442e12ce54973ddf4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/