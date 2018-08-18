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
	public class TransactionHistoryArchiveIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TransactionHistoryArchiveIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestCreate()
		{
			var response = await this.CreateRecord();

			response.Should().NotBeNull();

			await this.Cleanup();
		}

		[Fact]
		public async void TestUpdate()
		{
			var model = await this.CreateRecord();

			ApiTransactionHistoryArchiveModelMapper mapper = new ApiTransactionHistoryArchiveModelMapper();

			UpdateResponse<ApiTransactionHistoryArchiveResponseModel> updateResponse = await this.Client.TransactionHistoryArchiveUpdateAsync(model.TransactionID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TransactionHistoryArchiveDeleteAsync(model.TransactionID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTransactionHistoryArchiveResponseModel response = await this.Client.TransactionHistoryArchiveGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTransactionHistoryArchiveResponseModel> response = await this.Client.TransactionHistoryArchiveAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTransactionHistoryArchiveResponseModel> CreateRecord()
		{
			var model = new ApiTransactionHistoryArchiveRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiTransactionHistoryArchiveResponseModel> result = await this.Client.TransactionHistoryArchiveCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TransactionHistoryArchiveDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>28a61f0f4549fae621420b494797e910</Hash>
</Codenesium>*/