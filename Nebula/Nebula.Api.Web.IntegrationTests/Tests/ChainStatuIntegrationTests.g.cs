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
	[Trait("Table", "ChainStatu")]
	[Trait("Area", "Integration")]
	public class ChainStatuIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ChainStatuIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiChainStatuModelMapper mapper = new ApiChainStatuModelMapper();

			UpdateResponse<ApiChainStatuResponseModel> updateResponse = await this.Client.ChainStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ChainStatuDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiChainStatuResponseModel response = await this.Client.ChainStatuGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiChainStatuResponseModel> response = await this.Client.ChainStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiChainStatuResponseModel> CreateRecord()
		{
			var model = new ApiChainStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiChainStatuResponseModel> result = await this.Client.ChainStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ChainStatuDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>c86b00dd84ee443bcd01b36ff2a5a188</Hash>
</Codenesium>*/