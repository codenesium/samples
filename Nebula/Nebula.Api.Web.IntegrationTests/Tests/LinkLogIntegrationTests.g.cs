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
	[Trait("Table", "LinkLog")]
	[Trait("Area", "Integration")]
	public class LinkLogIntegrationTests
	{
		public LinkLogIntegrationTests()
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

			await client.LinkLogDeleteAsync(1);

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

			ApiLinkLogResponseModel model = await client.LinkLogGetAsync(1);

			ApiLinkLogModelMapper mapper = new ApiLinkLogModelMapper();

			UpdateResponse<ApiLinkLogResponseModel> updateResponse = await client.LinkLogUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiLinkLogRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiLinkLogResponseModel> createResult = await client.LinkLogCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiLinkLogResponseModel getResponse = await client.LinkLogGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.LinkLogDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiLinkLogResponseModel verifyResponse = await client.LinkLogGetAsync(2);

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
			ApiLinkLogResponseModel response = await client.LinkLogGetAsync(1);

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

			List<ApiLinkLogResponseModel> response = await client.LinkLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLinkLogResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiLinkLogRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiLinkLogResponseModel> result = await client.LinkLogCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>8dde37e7c3595c3c8332ae2fa3f567d8</Hash>
</Codenesium>*/