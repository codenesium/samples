using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Link")]
	[Trait("Area", "Integration")]
	public class LinkIntegrationTests
	{
		public LinkIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.LinkDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiLinkResponseModel model = await client.LinkGetAsync(1);

			ApiLinkModelMapper mapper = new ApiLinkModelMapper();

			UpdateResponse<ApiLinkResponseModel> updateResponse = await client.LinkUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			var createModel = new ApiLinkRequestModel();
			createModel.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, "B", 2, "B", "B", 2);
			CreateResponse<ApiLinkResponseModel> createResult = await client.LinkCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiLinkResponseModel getResponse = await client.LinkGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.LinkDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiLinkResponseModel verifyResponse = await client.LinkGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiLinkResponseModel response = await client.LinkGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiLinkResponseModel> response = await client.LinkAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLinkResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiLinkRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, "B", 2, "B", "B", 2);
			CreateResponse<ApiLinkResponseModel> result = await client.LinkCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>97a41ea632bc222e583fc64a7e90b80e</Hash>
</Codenesium>*/