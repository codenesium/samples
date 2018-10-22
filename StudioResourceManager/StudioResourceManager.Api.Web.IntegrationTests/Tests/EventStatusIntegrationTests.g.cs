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
	[Trait("Table", "EventStatus")]
	[Trait("Area", "Integration")]
	public class EventStatusIntegrationTests
	{
		public EventStatusIntegrationTests()
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

			await client.EventStatusDeleteAsync(1);

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

			ApiEventStatusResponseModel model = await client.EventStatusGetAsync(1);

			ApiEventStatusModelMapper mapper = new ApiEventStatusModelMapper();

			UpdateResponse<ApiEventStatusResponseModel> updateResponse = await client.EventStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiEventStatusRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiEventStatusResponseModel> createResult = await client.EventStatusCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiEventStatusResponseModel getResponse = await client.EventStatusGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.EventStatusDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiEventStatusResponseModel verifyResponse = await client.EventStatusGetAsync(2);

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
			ApiEventStatusResponseModel response = await client.EventStatusGetAsync(1);

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

			List<ApiEventStatusResponseModel> response = await client.EventStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventStatusResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEventStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiEventStatusResponseModel> result = await client.EventStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a9924fa3a1fb4491ab167878e0de615e</Hash>
</Codenesium>*/