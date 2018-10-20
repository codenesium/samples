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
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "Integration")]
	public class ErrorLogIntegrationTests
	{
		public ErrorLogIntegrationTests()
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

			await client.ErrorLogDeleteAsync(1);

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

			ApiErrorLogResponseModel model = await client.ErrorLogGetAsync(1);

			ApiErrorLogModelMapper mapper = new ApiErrorLogModelMapper();

			UpdateResponse<ApiErrorLogResponseModel> updateResponse = await client.ErrorLogUpdateAsync(model.ErrorLogID, mapper.MapResponseToRequest(model));

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

			ApiErrorLogResponseModel response = await client.ErrorLogGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ErrorLogDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ErrorLogGetAsync(1);

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
			ApiErrorLogResponseModel response = await client.ErrorLogGetAsync(1);

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

			List<ApiErrorLogResponseModel> response = await client.ErrorLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiErrorLogResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiErrorLogRequestModel();
			model.SetProperties(2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiErrorLogResponseModel> result = await client.ErrorLogCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>04b11d6e8d9ba76461c977ef6a5731fe</Hash>
</Codenesium>*/