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

			ApiLinkStatusResponseModel response = await client.LinkStatusGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.LinkStatusDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.LinkStatusGetAsync(1);

			response.Should().BeNull();
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
    <Hash>c7c59a04133a4ff461886f5829dfba25</Hash>
</Codenesium>*/