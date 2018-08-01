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
	[Trait("Table", "Chain")]
	[Trait("Area", "Integration")]
	public class ChainIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ChainIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiChainModelMapper mapper = new ApiChainModelMapper();

			UpdateResponse<ApiChainResponseModel> updateResponse = await this.Client.ChainUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ChainDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiChainResponseModel response = await this.Client.ChainGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiChainResponseModel> response = await this.Client.ChainAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiChainResponseModel> CreateRecord()
		{
			var model = new ApiChainRequestModel();
			model.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1);
			CreateResponse<ApiChainResponseModel> result = await this.Client.ChainCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ChainDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>cf30bd1e8da56e56376e3fc05864b06d</Hash>
</Codenesium>*/