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
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Integration")]
	public partial class RowVersionCheckIntegrationTests
	{
		public RowVersionCheckIntegrationTests()
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

			var model = new ApiRowVersionCheckClientRequestModel();
			model.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			var model2 = new ApiRowVersionCheckClientRequestModel();
			model2.SetProperties("C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			var request = new List<ApiRowVersionCheckClientRequestModel>() {model, model2};
			CreateResponse<List<ApiRowVersionCheckClientResponseModel>> result = await client.RowVersionCheckBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<RowVersionCheck>().ToList()[1].Name.Should().Be("B");
			context.Set<RowVersionCheck>().ToList()[1].RowVersion.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			context.Set<RowVersionCheck>().ToList()[2].Name.Should().Be("C");
			context.Set<RowVersionCheck>().ToList()[2].RowVersion.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
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

			var model = new ApiRowVersionCheckClientRequestModel();
			model.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiRowVersionCheckClientResponseModel> result = await client.RowVersionCheckCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<RowVersionCheck>().ToList()[1].Name.Should().Be("B");
			context.Set<RowVersionCheck>().ToList()[1].RowVersion.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			result.Record.Name.Should().Be("B");
			result.Record.RowVersion.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
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
			var mapper = new ApiRowVersionCheckServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IRowVersionCheckService service = testServer.Host.Services.GetService(typeof(IRowVersionCheckService)) as IRowVersionCheckService;
			ApiRowVersionCheckServerResponseModel model = await service.Get(1);

			ApiRowVersionCheckClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			UpdateResponse<ApiRowVersionCheckClientResponseModel> updateResponse = await client.RowVersionCheckUpdateAsync(model.Id, request);

			context.Entry(context.Set<RowVersionCheck>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<RowVersionCheck>().ToList()[0].Name.Should().Be("B");
			context.Set<RowVersionCheck>().ToList()[0].RowVersion.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.RowVersion.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
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

			IRowVersionCheckService service = testServer.Host.Services.GetService(typeof(IRowVersionCheckService)) as IRowVersionCheckService;
			var model = new ApiRowVersionCheckServerRequestModel();
			model.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiRowVersionCheckServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.RowVersionCheckDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiRowVersionCheckServerResponseModel verifyResponse = await service.Get(2);

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

			ApiRowVersionCheckClientResponseModel response = await client.RowVersionCheckGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
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
			ApiRowVersionCheckClientResponseModel response = await client.RowVersionCheckGetAsync(default(int));

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
			List<ApiRowVersionCheckClientResponseModel> response = await client.RowVersionCheckAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
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
				var result = await client.RowVersionCheckAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>3223a3527bbc5bcd0b9a77960f76a60b</Hash>
</Codenesium>*/