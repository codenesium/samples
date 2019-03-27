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
	[Trait("Table", "Link")]
	[Trait("Area", "Integration")]
	public partial class LinkIntegrationTests
	{
		public LinkIntegrationTests()
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

			var model = new ApiLinkClientRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, "B", 2, "B", "B", 2);
			var model2 = new ApiLinkClientRequestModel();
			model2.SetProperties(1, 1, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 1, "C", 3, "C", "C", 3);
			var request = new List<ApiLinkClientRequestModel>() {model, model2};
			CreateResponse<List<ApiLinkClientResponseModel>> result = await client.LinkBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Link>().ToList()[1].AssignedMachineId.Should().Be(1);
			context.Set<Link>().ToList()[1].ChainId.Should().Be(1);
			context.Set<Link>().ToList()[1].DateCompleted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Link>().ToList()[1].DateStarted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Link>().ToList()[1].DynamicParameters.Should().Be("B");
			context.Set<Link>().ToList()[1].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Link>().ToList()[1].LinkStatusId.Should().Be(1);
			context.Set<Link>().ToList()[1].Name.Should().Be("B");
			context.Set<Link>().ToList()[1].Order.Should().Be(2);
			context.Set<Link>().ToList()[1].Response.Should().Be("B");
			context.Set<Link>().ToList()[1].StaticParameters.Should().Be("B");
			context.Set<Link>().ToList()[1].TimeoutInSeconds.Should().Be(2);

			context.Set<Link>().ToList()[2].AssignedMachineId.Should().Be(1);
			context.Set<Link>().ToList()[2].ChainId.Should().Be(1);
			context.Set<Link>().ToList()[2].DateCompleted.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Link>().ToList()[2].DateStarted.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Link>().ToList()[2].DynamicParameters.Should().Be("C");
			context.Set<Link>().ToList()[2].ExternalId.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Link>().ToList()[2].LinkStatusId.Should().Be(1);
			context.Set<Link>().ToList()[2].Name.Should().Be("C");
			context.Set<Link>().ToList()[2].Order.Should().Be(3);
			context.Set<Link>().ToList()[2].Response.Should().Be("C");
			context.Set<Link>().ToList()[2].StaticParameters.Should().Be("C");
			context.Set<Link>().ToList()[2].TimeoutInSeconds.Should().Be(3);
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

			var model = new ApiLinkClientRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, "B", 2, "B", "B", 2);
			CreateResponse<ApiLinkClientResponseModel> result = await client.LinkCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Link>().ToList()[1].AssignedMachineId.Should().Be(1);
			context.Set<Link>().ToList()[1].ChainId.Should().Be(1);
			context.Set<Link>().ToList()[1].DateCompleted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Link>().ToList()[1].DateStarted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Link>().ToList()[1].DynamicParameters.Should().Be("B");
			context.Set<Link>().ToList()[1].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Link>().ToList()[1].LinkStatusId.Should().Be(1);
			context.Set<Link>().ToList()[1].Name.Should().Be("B");
			context.Set<Link>().ToList()[1].Order.Should().Be(2);
			context.Set<Link>().ToList()[1].Response.Should().Be("B");
			context.Set<Link>().ToList()[1].StaticParameters.Should().Be("B");
			context.Set<Link>().ToList()[1].TimeoutInSeconds.Should().Be(2);

			result.Record.AssignedMachineId.Should().Be(1);
			result.Record.ChainId.Should().Be(1);
			result.Record.DateCompleted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.DateStarted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.DynamicParameters.Should().Be("B");
			result.Record.ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.LinkStatusId.Should().Be(1);
			result.Record.Name.Should().Be("B");
			result.Record.Order.Should().Be(2);
			result.Record.Response.Should().Be("B");
			result.Record.StaticParameters.Should().Be("B");
			result.Record.TimeoutInSeconds.Should().Be(2);
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
			var mapper = new ApiLinkServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ILinkService service = testServer.Host.Services.GetService(typeof(ILinkService)) as ILinkService;
			ApiLinkServerResponseModel model = await service.Get(1);

			ApiLinkClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, "B", 2, "B", "B", 2);

			UpdateResponse<ApiLinkClientResponseModel> updateResponse = await client.LinkUpdateAsync(model.Id, request);

			context.Entry(context.Set<Link>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Link>().ToList()[0].AssignedMachineId.Should().Be(1);
			context.Set<Link>().ToList()[0].ChainId.Should().Be(1);
			context.Set<Link>().ToList()[0].DateCompleted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Link>().ToList()[0].DateStarted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Link>().ToList()[0].DynamicParameters.Should().Be("B");
			context.Set<Link>().ToList()[0].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Link>().ToList()[0].LinkStatusId.Should().Be(1);
			context.Set<Link>().ToList()[0].Name.Should().Be("B");
			context.Set<Link>().ToList()[0].Order.Should().Be(2);
			context.Set<Link>().ToList()[0].Response.Should().Be("B");
			context.Set<Link>().ToList()[0].StaticParameters.Should().Be("B");
			context.Set<Link>().ToList()[0].TimeoutInSeconds.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.AssignedMachineId.Should().Be(1);
			updateResponse.Record.ChainId.Should().Be(1);
			updateResponse.Record.DateCompleted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.DateStarted.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.DynamicParameters.Should().Be("B");
			updateResponse.Record.ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.LinkStatusId.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Order.Should().Be(2);
			updateResponse.Record.Response.Should().Be("B");
			updateResponse.Record.StaticParameters.Should().Be("B");
			updateResponse.Record.TimeoutInSeconds.Should().Be(2);
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

			ILinkService service = testServer.Host.Services.GetService(typeof(ILinkService)) as ILinkService;
			var model = new ApiLinkServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, "B", 2, "B", "B", 2);
			CreateResponse<ApiLinkServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.LinkDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiLinkServerResponseModel verifyResponse = await service.Get(2);

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

			ApiLinkClientResponseModel response = await client.LinkGetAsync(1);

			response.Should().NotBeNull();
			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
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
			ApiLinkClientResponseModel response = await client.LinkGetAsync(default(int));

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
			List<ApiLinkClientResponseModel> response = await client.LinkAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AssignedMachineId.Should().Be(1);
			response[0].ChainId.Should().Be(1);
			response[0].DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].DynamicParameters.Should().Be("A");
			response[0].ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Id.Should().Be(1);
			response[0].LinkStatusId.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Order.Should().Be(1);
			response[0].Response.Should().Be("A");
			response[0].StaticParameters.Should().Be("A");
			response[0].TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByExternalIdFound()
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
			ApiLinkClientResponseModel response = await client.ByLinkByExternalId(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByExternalIdNotFound()
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
			ApiLinkClientResponseModel response = await client.ByLinkByExternalId(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByChainIdFound()
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
			List<ApiLinkClientResponseModel> response = await client.ByLinkByChainId(1);

			response.Should().NotBeEmpty();
			response[0].AssignedMachineId.Should().Be(1);
			response[0].ChainId.Should().Be(1);
			response[0].DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].DynamicParameters.Should().Be("A");
			response[0].ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Id.Should().Be(1);
			response[0].LinkStatusId.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Order.Should().Be(1);
			response[0].Response.Should().Be("A");
			response[0].StaticParameters.Should().Be("A");
			response[0].TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByChainIdNotFound()
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
			List<ApiLinkClientResponseModel> response = await client.ByLinkByChainId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyLinkLogsByLinkIdFound()
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
			List<ApiLinkLogClientResponseModel> response = await client.LinkLogsByLinkId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyLinkLogsByLinkIdNotFound()
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
			List<ApiLinkLogClientResponseModel> response = await client.LinkLogsByLinkId(default(int));

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
				var result = await client.LinkAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>3f30c9a828a645af7031afe44cda4777</Hash>
</Codenesium>*/