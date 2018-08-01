using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Integration")]
	public class RowVersionCheckIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public RowVersionCheckIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiRowVersionCheckModelMapper mapper = new ApiRowVersionCheckModelMapper();

			UpdateResponse<ApiRowVersionCheckResponseModel> updateResponse = await this.Client.RowVersionCheckUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.RowVersionCheckDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiRowVersionCheckResponseModel response = await this.Client.RowVersionCheckGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiRowVersionCheckResponseModel> response = await this.Client.RowVersionCheckAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiRowVersionCheckResponseModel> CreateRecord()
		{
			var model = new ApiRowVersionCheckRequestModel();
			model.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiRowVersionCheckResponseModel> result = await this.Client.RowVersionCheckCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.RowVersionCheckDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>598b02f68fc719f32fa6cf49eaa6d762</Hash>
</Codenesium>*/