using FileServiceNS.Api.Client;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "Integration")]
	public class VersionInfoIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VersionInfoIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVersionInfoModelMapper mapper = new ApiVersionInfoModelMapper();

			UpdateResponse<ApiVersionInfoResponseModel> updateResponse = await this.Client.VersionInfoUpdateAsync(model.Version, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VersionInfoDeleteAsync(model.Version);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVersionInfoResponseModel response = await this.Client.VersionInfoGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVersionInfoResponseModel> response = await this.Client.VersionInfoAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVersionInfoResponseModel> CreateRecord()
		{
			var model = new ApiVersionInfoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiVersionInfoResponseModel> result = await this.Client.VersionInfoCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VersionInfoDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>4accb7b584332d7180048383d029b093</Hash>
</Codenesium>*/