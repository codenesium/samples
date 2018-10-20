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
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Integration")]
	public class ColumnSameAsFKTableIntegrationTests
	{
		public ColumnSameAsFKTableIntegrationTests()
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

			await client.ColumnSameAsFKTableDeleteAsync(1);

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

			ApiColumnSameAsFKTableResponseModel model = await client.ColumnSameAsFKTableGetAsync(1);

			ApiColumnSameAsFKTableModelMapper mapper = new ApiColumnSameAsFKTableModelMapper();

			UpdateResponse<ApiColumnSameAsFKTableResponseModel> updateResponse = await client.ColumnSameAsFKTableUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiColumnSameAsFKTableResponseModel response = await client.ColumnSameAsFKTableGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ColumnSameAsFKTableDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ColumnSameAsFKTableGetAsync(1);

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
			ApiColumnSameAsFKTableResponseModel response = await client.ColumnSameAsFKTableGetAsync(1);

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

			List<ApiColumnSameAsFKTableResponseModel> response = await client.ColumnSameAsFKTableAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiColumnSameAsFKTableResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiColumnSameAsFKTableRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiColumnSameAsFKTableResponseModel> result = await client.ColumnSameAsFKTableCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>2972ab0cf934e693e1fd09c2c11acb1c</Hash>
</Codenesium>*/