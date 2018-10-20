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
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "Integration")]
	public class TransactionHistoryIntegrationTests
	{
		public TransactionHistoryIntegrationTests()
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

			await client.TransactionHistoryDeleteAsync(1);

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

			ApiTransactionHistoryResponseModel model = await client.TransactionHistoryGetAsync(1);

			ApiTransactionHistoryModelMapper mapper = new ApiTransactionHistoryModelMapper();

			UpdateResponse<ApiTransactionHistoryResponseModel> updateResponse = await client.TransactionHistoryUpdateAsync(model.TransactionID, mapper.MapResponseToRequest(model));

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

			ApiTransactionHistoryResponseModel response = await client.TransactionHistoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.TransactionHistoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.TransactionHistoryGetAsync(1);

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
			ApiTransactionHistoryResponseModel response = await client.TransactionHistoryGetAsync(1);

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

			List<ApiTransactionHistoryResponseModel> response = await client.TransactionHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTransactionHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTransactionHistoryRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiTransactionHistoryResponseModel> result = await client.TransactionHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>f2fe6b86752bc30d1606f172481e14b3</Hash>
</Codenesium>*/