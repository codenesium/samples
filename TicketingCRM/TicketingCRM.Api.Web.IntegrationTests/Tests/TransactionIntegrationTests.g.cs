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
	[Trait("Table", "Transaction")]
	[Trait("Area", "Integration")]
	public class TransactionIntegrationTests
	{
		public TransactionIntegrationTests()
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

			await client.TransactionDeleteAsync(1);

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

			ApiTransactionResponseModel model = await client.TransactionGetAsync(1);

			ApiTransactionModelMapper mapper = new ApiTransactionModelMapper();

			UpdateResponse<ApiTransactionResponseModel> updateResponse = await client.TransactionUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTransactionRequestModel();
			createModel.SetProperties(2m, "B", 1);
			CreateResponse<ApiTransactionResponseModel> createResult = await client.TransactionCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTransactionResponseModel getResponse = await client.TransactionGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TransactionDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTransactionResponseModel verifyResponse = await client.TransactionGetAsync(2);

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
			ApiTransactionResponseModel response = await client.TransactionGetAsync(1);

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

			List<ApiTransactionResponseModel> response = await client.TransactionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTransactionResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTransactionRequestModel();
			model.SetProperties(2m, "B", 1);
			CreateResponse<ApiTransactionResponseModel> result = await client.TransactionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>41692aa91a0c63622f2ebd32b90caa42</Hash>
</Codenesium>*/