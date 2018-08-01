using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "Integration")]
	public class ChainStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ChainStatusIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiChainStatusModelMapper mapper = new ApiChainStatusModelMapper();

			UpdateResponse<ApiChainStatusResponseModel> updateResponse = await this.Client.ChainStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ChainStatusDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiChainStatusResponseModel response = await this.Client.ChainStatusGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiChainStatusResponseModel> response = await this.Client.ChainStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiChainStatusResponseModel> CreateRecord()
		{
			var model = new ApiChainStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiChainStatusResponseModel> result = await this.Client.ChainStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ChainStatusDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>9d7e7e5a939df1cf93789bcc50779a37</Hash>
</Codenesium>*/