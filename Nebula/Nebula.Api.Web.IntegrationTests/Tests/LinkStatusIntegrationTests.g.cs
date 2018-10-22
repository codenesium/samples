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
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "Integration")]
	public class LinkStatusIntegrationTests
	{
		public LinkStatusIntegrationTests()
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

			await client.LinkStatusDeleteAsync(1);

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

			ApiLinkStatusResponseModel model = await client.LinkStatusGetAsync(1);

			ApiLinkStatusModelMapper mapper = new ApiLinkStatusModelMapper();

			UpdateResponse<ApiLinkStatusResponseModel> updateResponse = await client.LinkStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiLinkStatusRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiLinkStatusResponseModel> createResult = await client.LinkStatusCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiLinkStatusResponseModel getResponse = await client.LinkStatusGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.LinkStatusDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiLinkStatusResponseModel verifyResponse = await client.LinkStatusGetAsync(2);

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
			ApiLinkStatusResponseModel response = await client.LinkStatusGetAsync(1);

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

			List<ApiLinkStatusResponseModel> response = await client.LinkStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLinkStatusResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiLinkStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiLinkStatusResponseModel> result = await client.LinkStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>0c2a5ec391fe23605b66131b72d008b2</Hash>
</Codenesium>*/