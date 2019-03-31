using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Client;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Message")]
	[Trait("Area", "Integration")]
	public partial class MessageIntegrationTests
	{
		public MessageIntegrationTests()
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

			var model = new ApiMessageClientRequestModel();
			model.SetProperties("B", 1);
			var model2 = new ApiMessageClientRequestModel();
			model2.SetProperties("C", 1);
			var request = new List<ApiMessageClientRequestModel>() {model, model2};
			CreateResponse<List<ApiMessageClientResponseModel>> result = await client.MessageBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Message>().ToList()[1].Content.Should().Be("B");
			context.Set<Message>().ToList()[1].SenderUserId.Should().Be(1);

			context.Set<Message>().ToList()[2].Content.Should().Be("C");
			context.Set<Message>().ToList()[2].SenderUserId.Should().Be(1);
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

			var model = new ApiMessageClientRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiMessageClientResponseModel> result = await client.MessageCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Message>().ToList()[1].Content.Should().Be("B");
			context.Set<Message>().ToList()[1].SenderUserId.Should().Be(1);

			result.Record.Content.Should().Be("B");
			result.Record.SenderUserId.Should().Be(1);
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
			var mapper = new ApiMessageServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IMessageService service = testServer.Host.Services.GetService(typeof(IMessageService)) as IMessageService;
			ApiMessageServerResponseModel model = await service.Get(1);

			ApiMessageClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 1);

			UpdateResponse<ApiMessageClientResponseModel> updateResponse = await client.MessageUpdateAsync(model.MessageId, request);

			context.Entry(context.Set<Message>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.MessageId.Should().Be(1);
			context.Set<Message>().ToList()[0].Content.Should().Be("B");
			context.Set<Message>().ToList()[0].SenderUserId.Should().Be(1);

			updateResponse.Record.MessageId.Should().Be(1);
			updateResponse.Record.Content.Should().Be("B");
			updateResponse.Record.SenderUserId.Should().Be(1);
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

			IMessageService service = testServer.Host.Services.GetService(typeof(IMessageService)) as IMessageService;
			var model = new ApiMessageServerRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiMessageServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.MessageDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiMessageServerResponseModel verifyResponse = await service.Get(2);

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

			ApiMessageClientResponseModel response = await client.MessageGetAsync(1);

			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.MessageId.Should().Be(1);
			response.SenderUserId.Should().Be(1);
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
			ApiMessageClientResponseModel response = await client.MessageGetAsync(default(int));

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
			List<ApiMessageClientResponseModel> response = await client.MessageAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Content.Should().Be("A");
			response[0].MessageId.Should().Be(1);
			response[0].SenderUserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySenderUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessageClientResponseModel> response = await client.ByMessageBySenderUserId(1);

			response.Should().NotBeEmpty();
			response[0].Content.Should().Be("A");
			response[0].MessageId.Should().Be(1);
			response[0].SenderUserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySenderUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessageClientResponseModel> response = await client.ByMessageBySenderUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessengersByMessageIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessengerClientResponseModel> response = await client.MessengersByMessageId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessengersByMessageIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessengerClientResponseModel> response = await client.MessengersByMessageId(default(int));

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
				var result = await client.MessageAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>97db7949e8ec7a0bc8a1b57335da8ef5</Hash>
</Codenesium>*/