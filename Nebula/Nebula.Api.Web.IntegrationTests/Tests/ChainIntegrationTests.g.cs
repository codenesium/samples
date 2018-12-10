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
	[Trait("Table", "Chain")]
	[Trait("Area", "Integration")]
	public partial class ChainIntegrationTests
	{
		public ChainIntegrationTests()
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiChainClientRequestModel();
			model.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1);
			var model2 = new ApiChainClientRequestModel();
			model2.SetProperties(1, Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), "C", 1);
			var request = new List<ApiChainClientRequestModel>() {model, model2};
			CreateResponse<List<ApiChainClientResponseModel>> result = await client.ChainBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Chain>().ToList()[1].ChainStatusId.Should().Be(1);
			context.Set<Chain>().ToList()[1].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Chain>().ToList()[1].Name.Should().Be("B");
			context.Set<Chain>().ToList()[1].TeamId.Should().Be(1);

			context.Set<Chain>().ToList()[2].ChainStatusId.Should().Be(1);
			context.Set<Chain>().ToList()[2].ExternalId.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Chain>().ToList()[2].Name.Should().Be("C");
			context.Set<Chain>().ToList()[2].TeamId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiChainClientRequestModel();
			model.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1);
			CreateResponse<ApiChainClientResponseModel> result = await client.ChainCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Chain>().ToList()[1].ChainStatusId.Should().Be(1);
			context.Set<Chain>().ToList()[1].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Chain>().ToList()[1].Name.Should().Be("B");
			context.Set<Chain>().ToList()[1].TeamId.Should().Be(1);

			result.Record.ChainStatusId.Should().Be(1);
			result.Record.ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.Name.Should().Be("B");
			result.Record.TeamId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiChainServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IChainService service = testServer.Host.Services.GetService(typeof(IChainService)) as IChainService;
			ApiChainServerResponseModel model = await service.Get(1);

			ApiChainClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1);

			UpdateResponse<ApiChainClientResponseModel> updateResponse = await client.ChainUpdateAsync(model.Id, request);

			context.Entry(context.Set<Chain>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Chain>().ToList()[0].ChainStatusId.Should().Be(1);
			context.Set<Chain>().ToList()[0].ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Chain>().ToList()[0].Name.Should().Be("B");
			context.Set<Chain>().ToList()[0].TeamId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.ChainStatusId.Should().Be(1);
			updateResponse.Record.ExternalId.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.TeamId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IChainService service = testServer.Host.Services.GetService(typeof(IChainService)) as IChainService;
			var model = new ApiChainServerRequestModel();
			model.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1);
			CreateResponse<ApiChainServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ChainDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiChainServerResponseModel verifyResponse = await service.Get(2);

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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiChainClientResponseModel response = await client.ChainGetAsync(1);

			response.Should().NotBeNull();
			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiChainClientResponseModel response = await client.ChainGetAsync(default(int));

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

			List<ApiChainClientResponseModel> response = await client.ChainAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ChainStatusId.Should().Be(1);
			response[0].ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].TeamId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByExternalIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiChainClientResponseModel response = await client.ByChainByExternalId(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByExternalIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiChainClientResponseModel response = await client.ByChainByExternalId(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeyClaspsByNextChainIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiClaspClientResponseModel> response = await client.ClaspsByNextChainId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyClaspsByNextChainIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiClaspClientResponseModel> response = await client.ClaspsByNextChainId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyClaspsByPreviousChainIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiClaspClientResponseModel> response = await client.ClaspsByPreviousChainId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyClaspsByPreviousChainIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiClaspClientResponseModel> response = await client.ClaspsByPreviousChainId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyLinksByChainIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiLinkClientResponseModel> response = await client.LinksByChainId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyLinksByChainIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiLinkClientResponseModel> response = await client.LinksByChainId(default(int));

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
				var result = await client.ChainAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>3bc1c806599adcf43e4d38b02e91ea68</Hash>
</Codenesium>*/