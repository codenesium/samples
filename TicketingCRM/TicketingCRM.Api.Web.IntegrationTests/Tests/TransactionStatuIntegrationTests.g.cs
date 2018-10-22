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
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "Integration")]
	public class TransactionStatuIntegrationTests
	{
		public TransactionStatuIntegrationTests()
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

			await client.TransactionStatuDeleteAsync(1);

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

			ApiTransactionStatuResponseModel model = await client.TransactionStatuGetAsync(1);

			ApiTransactionStatuModelMapper mapper = new ApiTransactionStatuModelMapper();

			UpdateResponse<ApiTransactionStatuResponseModel> updateResponse = await client.TransactionStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTransactionStatuRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiTransactionStatuResponseModel> createResult = await client.TransactionStatuCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTransactionStatuResponseModel getResponse = await client.TransactionStatuGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TransactionStatuDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTransactionStatuResponseModel verifyResponse = await client.TransactionStatuGetAsync(2);

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
			ApiTransactionStatuResponseModel response = await client.TransactionStatuGetAsync(1);

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

			List<ApiTransactionStatuResponseModel> response = await client.TransactionStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTransactionStatuResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTransactionStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTransactionStatuResponseModel> result = await client.TransactionStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>5901989c018f63a2c0e098b0749b5e73</Hash>
</Codenesium>*/