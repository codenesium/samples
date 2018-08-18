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
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "Integration")]
	public class CurrencyRateIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CurrencyRateIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCurrencyRateModelMapper mapper = new ApiCurrencyRateModelMapper();

			UpdateResponse<ApiCurrencyRateResponseModel> updateResponse = await this.Client.CurrencyRateUpdateAsync(model.CurrencyRateID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CurrencyRateDeleteAsync(model.CurrencyRateID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCurrencyRateResponseModel response = await this.Client.CurrencyRateGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCurrencyRateResponseModel> response = await this.Client.CurrencyRateAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCurrencyRateResponseModel> CreateRecord()
		{
			var model = new ApiCurrencyRateRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			CreateResponse<ApiCurrencyRateResponseModel> result = await this.Client.CurrencyRateCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CurrencyRateDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>3ff785b0e9d63ecc44c576b8b511b5d8</Hash>
</Codenesium>*/