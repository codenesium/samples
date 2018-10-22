using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Customer")]
	[Trait("Area", "Integration")]
	public class CustomerIntegrationTests
	{
		public CustomerIntegrationTests()
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

			await client.CustomerDeleteAsync(1);

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

			ApiCustomerResponseModel model = await client.CustomerGetAsync(1);

			ApiCustomerModelMapper mapper = new ApiCustomerModelMapper();

			UpdateResponse<ApiCustomerResponseModel> updateResponse = await client.CustomerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiCustomerRequestModel();
			createModel.SetProperties("B", "B", "B", "B");
			CreateResponse<ApiCustomerResponseModel> createResult = await client.CustomerCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiCustomerResponseModel getResponse = await client.CustomerGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.CustomerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiCustomerResponseModel verifyResponse = await client.CustomerGetAsync(2);

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
			ApiCustomerResponseModel response = await client.CustomerGetAsync(1);

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

			List<ApiCustomerResponseModel> response = await client.CustomerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCustomerResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCustomerRequestModel();
			model.SetProperties("B", "B", "B", "B");
			CreateResponse<ApiCustomerResponseModel> result = await client.CustomerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>7d3fdec799933bbbba3508faa2a16671</Hash>
</Codenesium>*/