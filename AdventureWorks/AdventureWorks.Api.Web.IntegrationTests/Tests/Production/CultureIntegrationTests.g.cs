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
	[Trait("Table", "Culture")]
	[Trait("Area", "Integration")]
	public class CultureIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CultureIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCultureModelMapper mapper = new ApiCultureModelMapper();

			UpdateResponse<ApiCultureResponseModel> updateResponse = await this.Client.CultureUpdateAsync(model.CultureID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CultureDeleteAsync(model.CultureID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCultureResponseModel response = await this.Client.CultureGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCultureResponseModel> response = await this.Client.CultureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCultureResponseModel> CreateRecord()
		{
			var model = new ApiCultureRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiCultureResponseModel> result = await this.Client.CultureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CultureDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>1369180d75bb65b146a2a3db28525a99</Hash>
</Codenesium>*/