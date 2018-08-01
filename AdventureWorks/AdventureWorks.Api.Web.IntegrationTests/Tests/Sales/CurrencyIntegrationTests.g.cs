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
	[Trait("Table", "Currency")]
	[Trait("Area", "Integration")]
	public class CurrencyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CurrencyIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCurrencyModelMapper mapper = new ApiCurrencyModelMapper();

			UpdateResponse<ApiCurrencyResponseModel> updateResponse = await this.Client.CurrencyUpdateAsync(model.CurrencyCode, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CurrencyDeleteAsync(model.CurrencyCode);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCurrencyResponseModel response = await this.Client.CurrencyGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCurrencyResponseModel> response = await this.Client.CurrencyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCurrencyResponseModel> CreateRecord()
		{
			var model = new ApiCurrencyRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiCurrencyResponseModel> result = await this.Client.CurrencyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CurrencyDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>1bdbb7a3036a777c9932bf4293fc7cae</Hash>
</Codenesium>*/