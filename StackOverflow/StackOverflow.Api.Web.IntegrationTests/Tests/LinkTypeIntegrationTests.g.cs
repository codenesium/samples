using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "Integration")]
	public class LinkTypeIntegrationTests
	{
		public LinkTypeIntegrationTests()
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

			await client.LinkTypeDeleteAsync(1);

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

			ApiLinkTypeResponseModel model = await client.LinkTypeGetAsync(1);

			ApiLinkTypeModelMapper mapper = new ApiLinkTypeModelMapper();

			UpdateResponse<ApiLinkTypeResponseModel> updateResponse = await client.LinkTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiLinkTypeResponseModel response = await client.LinkTypeGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.LinkTypeDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.LinkTypeGetAsync(1);

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
			ApiLinkTypeResponseModel response = await client.LinkTypeGetAsync(1);

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

			List<ApiLinkTypeResponseModel> response = await client.LinkTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLinkTypeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiLinkTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiLinkTypeResponseModel> result = await client.LinkTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>9e32203661a9fb3bb3d787ffcdd23772</Hash>
</Codenesium>*/