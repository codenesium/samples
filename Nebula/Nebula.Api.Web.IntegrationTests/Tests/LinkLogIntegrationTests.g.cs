using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "Integration")]
	public partial class LinkLogIntegrationTests
	{
		public LinkLogIntegrationTests()
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

			var model = new ApiLinkLogClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			var model2 = new ApiLinkLogClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 1, "C");
			var request = new List<ApiLinkLogClientRequestModel>() {model, model2};
			CreateResponse<List<ApiLinkLogClientResponseModel>> result = await client.LinkLogBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<LinkLog>().ToList()[1].DateEntered.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<LinkLog>().ToList()[1].LinkId.Should().Be(1);
			context.Set<LinkLog>().ToList()[1].Log.Should().Be("B");

			context.Set<LinkLog>().ToList()[2].DateEntered.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<LinkLog>().ToList()[2].LinkId.Should().Be(1);
			context.Set<LinkLog>().ToList()[2].Log.Should().Be("C");
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

			var model = new ApiLinkLogClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiLinkLogClientResponseModel> result = await client.LinkLogCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<LinkLog>().ToList()[1].DateEntered.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<LinkLog>().ToList()[1].LinkId.Should().Be(1);
			context.Set<LinkLog>().ToList()[1].Log.Should().Be("B");

			result.Record.DateEntered.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.LinkId.Should().Be(1);
			result.Record.Log.Should().Be("B");
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
			var mapper = new ApiLinkLogServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ILinkLogService service = testServer.Host.Services.GetService(typeof(ILinkLogService)) as ILinkLogService;
			ApiLinkLogServerResponseModel model = await service.Get(1);

			ApiLinkLogClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");

			UpdateResponse<ApiLinkLogClientResponseModel> updateResponse = await client.LinkLogUpdateAsync(model.Id, request);

			context.Entry(context.Set<LinkLog>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<LinkLog>().ToList()[0].DateEntered.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<LinkLog>().ToList()[0].LinkId.Should().Be(1);
			context.Set<LinkLog>().ToList()[0].Log.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.DateEntered.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.LinkId.Should().Be(1);
			updateResponse.Record.Log.Should().Be("B");
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

			ILinkLogService service = testServer.Host.Services.GetService(typeof(ILinkLogService)) as ILinkLogService;
			var model = new ApiLinkLogServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiLinkLogServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.LinkLogDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiLinkLogServerResponseModel verifyResponse = await service.Get(2);

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

			ApiLinkLogClientResponseModel response = await client.LinkLogGetAsync(1);

			response.Should().NotBeNull();
			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
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
			ApiLinkLogClientResponseModel response = await client.LinkLogGetAsync(default(int));

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
			List<ApiLinkLogClientResponseModel> response = await client.LinkLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].LinkId.Should().Be(1);
			response[0].Log.Should().Be("A");
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
				var result = await client.LinkLogAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>8a44e08914bcdc65895cfd37bca20b74</Hash>
</Codenesium>*/