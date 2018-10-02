using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Location")]
	[Trait("Area", "Integration")]
	public class LocationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LocationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLocationModelMapper mapper = new ApiLocationModelMapper();

			UpdateResponse<ApiLocationResponseModel> updateResponse = await this.Client.LocationUpdateAsync(model.LocationId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LocationDeleteAsync(model.LocationId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLocationResponseModel response = await this.Client.LocationGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLocationResponseModel> response = await this.Client.LocationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLocationResponseModel> CreateRecord()
		{
			var model = new ApiLocationRequestModel();
			model.SetProperties(2, 2, "B");
			CreateResponse<ApiLocationResponseModel> result = await this.Client.LocationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LocationDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>9497379183f275450bac98d2cfb689d2</Hash>
</Codenesium>*/