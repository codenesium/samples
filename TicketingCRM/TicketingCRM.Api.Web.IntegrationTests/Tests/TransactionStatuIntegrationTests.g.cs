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
	public class TransactionStatuIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TransactionStatuIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTransactionStatuModelMapper mapper = new ApiTransactionStatuModelMapper();

			UpdateResponse<ApiTransactionStatuResponseModel> updateResponse = await this.Client.TransactionStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TransactionStatuDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTransactionStatuResponseModel response = await this.Client.TransactionStatuGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTransactionStatuResponseModel> response = await this.Client.TransactionStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTransactionStatuResponseModel> CreateRecord()
		{
			var model = new ApiTransactionStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTransactionStatuResponseModel> result = await this.Client.TransactionStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TransactionStatuDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>e1abe7862a0983af601f91fc22bb2098</Hash>
</Codenesium>*/