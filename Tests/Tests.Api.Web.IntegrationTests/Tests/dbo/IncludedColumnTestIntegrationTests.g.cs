using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Integration")]
	public class IncludedColumnTestIntegrationTests
	{
		public IncludedColumnTestIntegrationTests()
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

			await client.IncludedColumnTestDeleteAsync(1);

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

			ApiIncludedColumnTestResponseModel model = await client.IncludedColumnTestGetAsync(1);

			ApiIncludedColumnTestModelMapper mapper = new ApiIncludedColumnTestModelMapper();

			UpdateResponse<ApiIncludedColumnTestResponseModel> updateResponse = await client.IncludedColumnTestUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiIncludedColumnTestResponseModel response = await client.IncludedColumnTestGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.IncludedColumnTestDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.IncludedColumnTestGetAsync(1);

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
			ApiIncludedColumnTestResponseModel response = await client.IncludedColumnTestGetAsync(1);

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

			List<ApiIncludedColumnTestResponseModel> response = await client.IncludedColumnTestAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiIncludedColumnTestResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiIncludedColumnTestRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiIncludedColumnTestResponseModel> result = await client.IncludedColumnTestCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>dbfca58bacfcec355ead079374a075e0</Hash>
</Codenesium>*/