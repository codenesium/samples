using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "Integration")]
	public class EventStudentIntegrationTests
	{
		public EventStudentIntegrationTests()
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

			await client.EventStudentDeleteAsync(1);

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

			ApiEventStudentResponseModel model = await client.EventStudentGetAsync(1);

			ApiEventStudentModelMapper mapper = new ApiEventStudentModelMapper();

			UpdateResponse<ApiEventStudentResponseModel> updateResponse = await client.EventStudentUpdateAsync(model.EventId, mapper.MapResponseToRequest(model));

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

			ApiEventStudentResponseModel response = await client.EventStudentGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.EventStudentDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.EventStudentGetAsync(1);

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
			ApiEventStudentResponseModel response = await client.EventStudentGetAsync(1);

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

			List<ApiEventStudentResponseModel> response = await client.EventStudentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventStudentResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEventStudentRequestModel();
			model.SetProperties(1, true);
			CreateResponse<ApiEventStudentResponseModel> result = await client.EventStudentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c408f0d30166adbf357e2b798fa79f39</Hash>
</Codenesium>*/