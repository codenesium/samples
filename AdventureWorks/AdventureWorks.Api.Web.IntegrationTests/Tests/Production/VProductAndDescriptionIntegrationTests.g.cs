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
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "Integration")]
	public class VProductAndDescriptionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VProductAndDescriptionIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVProductAndDescriptionModelMapper mapper = new ApiVProductAndDescriptionModelMapper();

			UpdateResponse<ApiVProductAndDescriptionResponseModel> updateResponse = await this.Client.VProductAndDescriptionUpdateAsync(model.CultureID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VProductAndDescriptionDeleteAsync(model.CultureID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVProductAndDescriptionResponseModel response = await this.Client.VProductAndDescriptionGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVProductAndDescriptionResponseModel> response = await this.Client.VProductAndDescriptionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVProductAndDescriptionResponseModel> CreateRecord()
		{
			var model = new ApiVProductAndDescriptionRequestModel();
			model.SetProperties("B", "B", 2, "B");
			CreateResponse<ApiVProductAndDescriptionResponseModel> result = await this.Client.VProductAndDescriptionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VProductAndDescriptionDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>eb03712753293e902c4d8b3b62a8ce74</Hash>
</Codenesium>*/