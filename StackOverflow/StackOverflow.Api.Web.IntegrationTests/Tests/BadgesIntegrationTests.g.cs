using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Badges")]
	[Trait("Area", "Integration")]
	public partial class BadgesIntegrationTests
	{
		public BadgesIntegrationTests()
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

			var model = new ApiBadgesClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			var model2 = new ApiBadgesClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), "C", 1);
			var request = new List<ApiBadgesClientRequestModel>() {model, model2};
			CreateResponse<List<ApiBadgesClientResponseModel>> result = await client.BadgesBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Badges>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Badges>().ToList()[1].Name.Should().Be("B");
			context.Set<Badges>().ToList()[1].UserId.Should().Be(1);

			context.Set<Badges>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Badges>().ToList()[2].Name.Should().Be("C");
			context.Set<Badges>().ToList()[2].UserId.Should().Be(1);
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

			var model = new ApiBadgesClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			CreateResponse<ApiBadgesClientResponseModel> result = await client.BadgesCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Badges>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Badges>().ToList()[1].Name.Should().Be("B");
			context.Set<Badges>().ToList()[1].UserId.Should().Be(1);

			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Name.Should().Be("B");
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
			var mapper = new ApiBadgesServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IBadgesService service = testServer.Host.Services.GetService(typeof(IBadgesService)) as IBadgesService;
			ApiBadgesServerResponseModel model = await service.Get(1);

			ApiBadgesClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);

			UpdateResponse<ApiBadgesClientResponseModel> updateResponse = await client.BadgesUpdateAsync(model.Id, request);

			context.Entry(context.Set<Badges>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Badges>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Badges>().ToList()[0].Name.Should().Be("B");
			context.Set<Badges>().ToList()[0].UserId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Name.Should().Be("B");
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

			IBadgesService service = testServer.Host.Services.GetService(typeof(IBadgesService)) as IBadgesService;
			var model = new ApiBadgesServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			CreateResponse<ApiBadgesServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.BadgesDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiBadgesServerResponseModel verifyResponse = await service.Get(2);

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

			ApiBadgesClientResponseModel response = await client.BadgesGetAsync(1);

			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
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
			ApiBadgesClientResponseModel response = await client.BadgesGetAsync(default(int));

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
			List<ApiBadgesClientResponseModel> response = await client.BadgesAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].UserId.Should().Be(1);
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
			List<ApiBadgesClientResponseModel> response = await client.ByBadgesByUserId(1);

			response.Should().NotBeEmpty();
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
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
			List<ApiBadgesClientResponseModel> response = await client.ByBadgesByUserId(default(int));

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
				var result = await client.BadgesAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>2ea074cf4bf534a278b003736c9d98b7</Hash>
</Codenesium>*/