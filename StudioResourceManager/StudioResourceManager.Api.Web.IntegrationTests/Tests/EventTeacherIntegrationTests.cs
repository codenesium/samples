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
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "Integration")]
	public partial class EventTeacherIntegrationTests
	{
		public EventTeacherIntegrationTests()
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

			var model = new ApiEventTeacherClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiEventTeacherClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiEventTeacherClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEventTeacherClientResponseModel>> result = await client.EventTeacherBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<EventTeacher>().ToList()[1].EventId.Should().Be(1);
			context.Set<EventTeacher>().ToList()[1].TeacherId.Should().Be(1);

			context.Set<EventTeacher>().ToList()[2].EventId.Should().Be(1);
			context.Set<EventTeacher>().ToList()[2].TeacherId.Should().Be(1);
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

			var model = new ApiEventTeacherClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiEventTeacherClientResponseModel> result = await client.EventTeacherCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<EventTeacher>().ToList()[1].EventId.Should().Be(1);
			context.Set<EventTeacher>().ToList()[1].TeacherId.Should().Be(1);

			result.Record.EventId.Should().Be(1);
			result.Record.TeacherId.Should().Be(1);
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
			var mapper = new ApiEventTeacherServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IEventTeacherService service = testServer.Host.Services.GetService(typeof(IEventTeacherService)) as IEventTeacherService;
			ApiEventTeacherServerResponseModel model = await service.Get(1);

			ApiEventTeacherClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiEventTeacherClientResponseModel> updateResponse = await client.EventTeacherUpdateAsync(model.Id, request);

			context.Entry(context.Set<EventTeacher>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<EventTeacher>().ToList()[0].EventId.Should().Be(1);
			context.Set<EventTeacher>().ToList()[0].TeacherId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.EventId.Should().Be(1);
			updateResponse.Record.TeacherId.Should().Be(1);
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

			IEventTeacherService service = testServer.Host.Services.GetService(typeof(IEventTeacherService)) as IEventTeacherService;
			var model = new ApiEventTeacherServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiEventTeacherServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.EventTeacherDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiEventTeacherServerResponseModel verifyResponse = await service.Get(2);

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

			ApiEventTeacherClientResponseModel response = await client.EventTeacherGetAsync(1);

			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
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
			ApiEventTeacherClientResponseModel response = await client.EventTeacherGetAsync(default(int));

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
			List<ApiEventTeacherClientResponseModel> response = await client.EventTeacherAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].EventId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].TeacherId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTeacherIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventTeacherClientResponseModel> response = await client.ByEventTeacherByTeacherId(1);

			response.Should().NotBeEmpty();
			response[0].EventId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].TeacherId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTeacherIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventTeacherClientResponseModel> response = await client.ByEventTeacherByTeacherId(default(int));

			response.Should().BeEmpty();
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
			List<ApiEventTeacherClientResponseModel> response = await client.ByEventTeacherByEventId(1);

			response.Should().NotBeEmpty();
			response[0].EventId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].TeacherId.Should().Be(1);
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
			List<ApiEventTeacherClientResponseModel> response = await client.ByEventTeacherByEventId(default(int));

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
				var result = await client.EventTeacherAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>b129b325050c66ddc32db11ab0aa414f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/