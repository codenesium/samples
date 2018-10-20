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
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Integration")]
	public class TransactionHistoryArchiveIntegrationTests
	{
		public TransactionHistoryArchiveIntegrationTests()
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

			await client.TransactionHistoryArchiveDeleteAsync(1);

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

			ApiTransactionHistoryArchiveResponseModel model = await client.TransactionHistoryArchiveGetAsync(1);

			ApiTransactionHistoryArchiveModelMapper mapper = new ApiTransactionHistoryArchiveModelMapper();

			UpdateResponse<ApiTransactionHistoryArchiveResponseModel> updateResponse = await client.TransactionHistoryArchiveUpdateAsync(model.TransactionID, mapper.MapResponseToRequest(model));

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

			ApiTransactionHistoryArchiveResponseModel response = await client.TransactionHistoryArchiveGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.TransactionHistoryArchiveDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.TransactionHistoryArchiveGetAsync(1);

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
			ApiTransactionHistoryArchiveResponseModel response = await client.TransactionHistoryArchiveGetAsync(1);

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

			List<ApiTransactionHistoryArchiveResponseModel> response = await client.TransactionHistoryArchiveAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTransactionHistoryArchiveResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTransactionHistoryArchiveRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiTransactionHistoryArchiveResponseModel> result = await client.TransactionHistoryArchiveCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>685337412368a5b57a55365841c55e54</Hash>
</Codenesium>*/