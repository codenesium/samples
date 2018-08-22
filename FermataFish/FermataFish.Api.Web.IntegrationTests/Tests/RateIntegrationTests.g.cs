using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Rate")]
	[Trait("Area", "Integration")]
	public class RateIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public RateIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiRateModelMapper mapper = new ApiRateModelMapper();

			UpdateResponse<ApiRateResponseModel> updateResponse = await this.Client.RateUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.RateDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiRateResponseModel response = await this.Client.RateGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiRateResponseModel> response = await this.Client.RateAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiRateResponseModel> CreateRecord()
		{
			var model = new ApiRateRequestModel();
			model.SetProperties(2m, 1, 1, 1);
			CreateResponse<ApiRateResponseModel> result = await this.Client.RateCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.RateDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>57d8ef92d4392bc0b6f8a6f6636f085e</Hash>
</Codenesium>*/