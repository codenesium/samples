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
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "Integration")]
	public class TimestampCheckIntegrationTests
	{
		public TimestampCheckIntegrationTests()
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

			await client.TimestampCheckDeleteAsync(1);

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

			ApiTimestampCheckResponseModel model = await client.TimestampCheckGetAsync(1);

			ApiTimestampCheckModelMapper mapper = new ApiTimestampCheckModelMapper();

			UpdateResponse<ApiTimestampCheckResponseModel> updateResponse = await client.TimestampCheckUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiTimestampCheckResponseModel response = await client.TimestampCheckGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.TimestampCheckDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.TimestampCheckGetAsync(1);

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
			ApiTimestampCheckResponseModel response = await client.TimestampCheckGetAsync(1);

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

			List<ApiTimestampCheckResponseModel> response = await client.TimestampCheckAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTimestampCheckResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTimestampCheckRequestModel();
			model.SetProperties("B", BitConverter.GetBytes(2));
			CreateResponse<ApiTimestampCheckResponseModel> result = await client.TimestampCheckCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>850f81af7cdd44bf7c55c153bb28a02a</Hash>
</Codenesium>*/