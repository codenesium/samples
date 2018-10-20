using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "Integration")]
	public class DatabaseLogIntegrationTests
	{
		public DatabaseLogIntegrationTests()
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

			await client.DatabaseLogDeleteAsync(1);

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

			ApiDatabaseLogResponseModel model = await client.DatabaseLogGetAsync(1);

			ApiDatabaseLogModelMapper mapper = new ApiDatabaseLogModelMapper();

			UpdateResponse<ApiDatabaseLogResponseModel> updateResponse = await client.DatabaseLogUpdateAsync(model.DatabaseLogID, mapper.MapResponseToRequest(model));

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

			ApiDatabaseLogResponseModel response = await client.DatabaseLogGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.DatabaseLogDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.DatabaseLogGetAsync(1);

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
			ApiDatabaseLogResponseModel response = await client.DatabaseLogGetAsync(1);

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

			List<ApiDatabaseLogResponseModel> response = await client.DatabaseLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDatabaseLogResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiDatabaseLogRequestModel();
			model.SetProperties("B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B");
			CreateResponse<ApiDatabaseLogResponseModel> result = await client.DatabaseLogCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ed0409694602557d22f84a285f054760</Hash>
</Codenesium>*/