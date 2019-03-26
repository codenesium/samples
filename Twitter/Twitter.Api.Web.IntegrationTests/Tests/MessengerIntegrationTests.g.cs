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
	[Trait("Table", "Messenger")]
	[Trait("Area", "Integration")]
	public partial class MessengerIntegrationTests
	{
		public MessengerIntegrationTests()
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

			var model = new ApiMessengerClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
			var model2 = new ApiMessengerClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 1, TimeSpan.Parse("03:00:00"), 1, 1);
			var request = new List<ApiMessengerClientRequestModel>() {model, model2};
			CreateResponse<List<ApiMessengerClientResponseModel>> result = await client.MessengerBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Messenger>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Messenger>().ToList()[1].FromUserId.Should().Be(2);
			context.Set<Messenger>().ToList()[1].MessageId.Should().Be(1);
			context.Set<Messenger>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Messenger>().ToList()[1].ToUserId.Should().Be(1);
			context.Set<Messenger>().ToList()[1].UserId.Should().Be(1);

			context.Set<Messenger>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Messenger>().ToList()[2].FromUserId.Should().Be(3);
			context.Set<Messenger>().ToList()[2].MessageId.Should().Be(1);
			context.Set<Messenger>().ToList()[2].Time.Should().Be(TimeSpan.Parse("03:00:00"));
			context.Set<Messenger>().ToList()[2].ToUserId.Should().Be(1);
			context.Set<Messenger>().ToList()[2].UserId.Should().Be(1);
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

			var model = new ApiMessengerClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
			CreateResponse<ApiMessengerClientResponseModel> result = await client.MessengerCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Messenger>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Messenger>().ToList()[1].FromUserId.Should().Be(2);
			context.Set<Messenger>().ToList()[1].MessageId.Should().Be(1);
			context.Set<Messenger>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Messenger>().ToList()[1].ToUserId.Should().Be(1);
			context.Set<Messenger>().ToList()[1].UserId.Should().Be(1);

			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FromUserId.Should().Be(2);
			result.Record.MessageId.Should().Be(1);
			result.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
			result.Record.ToUserId.Should().Be(1);
			result.Record.UserId.Should().Be(1);
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
			var mapper = new ApiMessengerServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IMessengerService service = testServer.Host.Services.GetService(typeof(IMessengerService)) as IMessengerService;
			ApiMessengerServerResponseModel model = await service.Get(1);

			ApiMessengerClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);

			UpdateResponse<ApiMessengerClientResponseModel> updateResponse = await client.MessengerUpdateAsync(model.Id, request);

			context.Entry(context.Set<Messenger>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Messenger>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Messenger>().ToList()[0].FromUserId.Should().Be(2);
			context.Set<Messenger>().ToList()[0].MessageId.Should().Be(1);
			context.Set<Messenger>().ToList()[0].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Messenger>().ToList()[0].ToUserId.Should().Be(1);
			context.Set<Messenger>().ToList()[0].UserId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FromUserId.Should().Be(2);
			updateResponse.Record.MessageId.Should().Be(1);
			updateResponse.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
			updateResponse.Record.ToUserId.Should().Be(1);
			updateResponse.Record.UserId.Should().Be(1);
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

			IMessengerService service = testServer.Host.Services.GetService(typeof(IMessengerService)) as IMessengerService;
			var model = new ApiMessengerServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("02:00:00"), 1, 1);
			CreateResponse<ApiMessengerServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.MessengerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiMessengerServerResponseModel verifyResponse = await service.Get(2);

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

			ApiMessengerClientResponseModel response = await client.MessengerGetAsync(1);

			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.Id.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
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
			ApiMessengerClientResponseModel response = await client.MessengerGetAsync(default(int));

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
			List<ApiMessengerClientResponseModel> response = await client.MessengerAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FromUserId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].MessageId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].ToUserId.Should().Be(1);
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByMessageIdFound()
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
			List<ApiMessengerClientResponseModel> response = await client.ByMessengerByMessageId(1);

			response.Should().NotBeEmpty();
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FromUserId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].MessageId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].ToUserId.Should().Be(1);
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByMessageIdNotFound()
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
			List<ApiMessengerClientResponseModel> response = await client.ByMessengerByMessageId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByToUserIdFound()
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
			List<ApiMessengerClientResponseModel> response = await client.ByMessengerByToUserId(1);

			response.Should().NotBeEmpty();
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FromUserId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].MessageId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].ToUserId.Should().Be(1);
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByToUserIdNotFound()
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
			List<ApiMessengerClientResponseModel> response = await client.ByMessengerByToUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByUserIdFound()
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
			List<ApiMessengerClientResponseModel> response = await client.ByMessengerByUserId(1);

			response.Should().NotBeEmpty();
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FromUserId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].MessageId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].ToUserId.Should().Be(1);
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByUserIdNotFound()
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
			List<ApiMessengerClientResponseModel> response = await client.ByMessengerByUserId(default(int));

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
				var result = await client.MessengerAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>0a1ac90dbb4f9feb03bd2fc197ad87fc</Hash>
</Codenesium>*/