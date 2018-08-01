using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "Integration")]
	public class CountryRequirementIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CountryRequirementIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCountryRequirementModelMapper mapper = new ApiCountryRequirementModelMapper();

			UpdateResponse<ApiCountryRequirementResponseModel> updateResponse = await this.Client.CountryRequirementUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CountryRequirementDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCountryRequirementResponseModel response = await this.Client.CountryRequirementGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCountryRequirementResponseModel> response = await this.Client.CountryRequirementAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCountryRequirementResponseModel> CreateRecord()
		{
			var model = new ApiCountryRequirementRequestModel();
			model.SetProperties(1, "B");
			CreateResponse<ApiCountryRequirementResponseModel> result = await this.Client.CountryRequirementCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CountryRequirementDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>4c8dff2ad99af10d9c4007f533c39741</Hash>
</Codenesium>*/