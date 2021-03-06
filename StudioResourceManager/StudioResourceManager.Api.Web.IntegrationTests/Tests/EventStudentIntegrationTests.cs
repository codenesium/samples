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
	[Trait("Table", "EventStudent")]
	[Trait("Area", "Integration")]
	public partial class EventStudentIntegrationTests
	{
		public EventStudentIntegrationTests()
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

			var model = new ApiEventStudentClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiEventStudentClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiEventStudentClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEventStudentClientResponseModel>> result = await client.EventStudentBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<EventStudent>().ToList()[1].EventId.Should().Be(1);
			context.Set<EventStudent>().ToList()[1].StudentId.Should().Be(1);

			context.Set<EventStudent>().ToList()[2].EventId.Should().Be(1);
			context.Set<EventStudent>().ToList()[2].StudentId.Should().Be(1);
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

			var model = new ApiEventStudentClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiEventStudentClientResponseModel> result = await client.EventStudentCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<EventStudent>().ToList()[1].EventId.Should().Be(1);
			context.Set<EventStudent>().ToList()[1].StudentId.Should().Be(1);

			result.Record.EventId.Should().Be(1);
			result.Record.StudentId.Should().Be(1);
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
			var mapper = new ApiEventStudentServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IEventStudentService service = testServer.Host.Services.GetService(typeof(IEventStudentService)) as IEventStudentService;
			ApiEventStudentServerResponseModel model = await service.Get(1);

			ApiEventStudentClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiEventStudentClientResponseModel> updateResponse = await client.EventStudentUpdateAsync(model.Id, request);

			context.Entry(context.Set<EventStudent>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<EventStudent>().ToList()[0].EventId.Should().Be(1);
			context.Set<EventStudent>().ToList()[0].StudentId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.EventId.Should().Be(1);
			updateResponse.Record.StudentId.Should().Be(1);
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

			IEventStudentService service = testServer.Host.Services.GetService(typeof(IEventStudentService)) as IEventStudentService;
			var model = new ApiEventStudentServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiEventStudentServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.EventStudentDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiEventStudentServerResponseModel verifyResponse = await service.Get(2);

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

			ApiEventStudentClientResponseModel response = await client.EventStudentGetAsync(1);

			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.Id.Should().Be(1);
			response.StudentId.Should().Be(1);
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
			ApiEventStudentClientResponseModel response = await client.EventStudentGetAsync(default(int));

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
			List<ApiEventStudentClientResponseModel> response = await client.EventStudentAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].EventId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].StudentId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByEventIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventStudentClientResponseModel> response = await client.ByEventStudentByEventId(1);

			response.Should().NotBeEmpty();
			response[0].EventId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].StudentId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByEventIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventStudentClientResponseModel> response = await client.ByEventStudentByEventId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByStudentIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventStudentClientResponseModel> response = await client.ByEventStudentByStudentId(1);

			response.Should().NotBeEmpty();
			response[0].EventId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].StudentId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByStudentIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventStudentClientResponseModel> response = await client.ByEventStudentByStudentId(default(int));

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
				var result = await client.EventStudentAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>1e3e8fdef3096790e381110c9349b796</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/