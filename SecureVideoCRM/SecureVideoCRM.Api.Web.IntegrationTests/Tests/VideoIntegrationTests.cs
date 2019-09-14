using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using SecureVideoCRMNS.Api.Client;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using SecureVideoCRMNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SecureVideoCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Video")]
	[Trait("Area", "Integration")]
	public partial class VideoIntegrationTests
	{
		public VideoIntegrationTests()
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

			var model = new ApiVideoClientRequestModel();
			model.SetProperties("B", "B", "B");
			var model2 = new ApiVideoClientRequestModel();
			model2.SetProperties("C", "C", "C");
			var request = new List<ApiVideoClientRequestModel>() {model, model2};
			CreateResponse<List<ApiVideoClientResponseModel>> result = await client.VideoBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Video>().ToList()[1].Description.Should().Be("B");
			context.Set<Video>().ToList()[1].Title.Should().Be("B");
			context.Set<Video>().ToList()[1].Url.Should().Be("B");

			context.Set<Video>().ToList()[2].Description.Should().Be("C");
			context.Set<Video>().ToList()[2].Title.Should().Be("C");
			context.Set<Video>().ToList()[2].Url.Should().Be("C");
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

			var model = new ApiVideoClientRequestModel();
			model.SetProperties("B", "B", "B");
			CreateResponse<ApiVideoClientResponseModel> result = await client.VideoCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Video>().ToList()[1].Description.Should().Be("B");
			context.Set<Video>().ToList()[1].Title.Should().Be("B");
			context.Set<Video>().ToList()[1].Url.Should().Be("B");

			result.Record.Description.Should().Be("B");
			result.Record.Title.Should().Be("B");
			result.Record.Url.Should().Be("B");
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
			var mapper = new ApiVideoServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IVideoService service = testServer.Host.Services.GetService(typeof(IVideoService)) as IVideoService;
			ApiVideoServerResponseModel model = await service.Get(1);

			ApiVideoClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B");

			UpdateResponse<ApiVideoClientResponseModel> updateResponse = await client.VideoUpdateAsync(model.Id, request);

			context.Entry(context.Set<Video>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Video>().ToList()[0].Description.Should().Be("B");
			context.Set<Video>().ToList()[0].Title.Should().Be("B");
			context.Set<Video>().ToList()[0].Url.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.Title.Should().Be("B");
			updateResponse.Record.Url.Should().Be("B");
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

			IVideoService service = testServer.Host.Services.GetService(typeof(IVideoService)) as IVideoService;
			var model = new ApiVideoServerRequestModel();
			model.SetProperties("B", "B", "B");
			CreateResponse<ApiVideoServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.VideoDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiVideoServerResponseModel verifyResponse = await service.Get(2);

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

			ApiVideoClientResponseModel response = await client.VideoGetAsync(1);

			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
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
			ApiVideoClientResponseModel response = await client.VideoGetAsync(default(int));

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
			List<ApiVideoClientResponseModel> response = await client.VideoAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Description.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Title.Should().Be("A");
			response[0].Url.Should().Be("A");
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
				var result = await client.VideoAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>1395cf4de6d9518fbc23803649093a17</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/