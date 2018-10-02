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
	[Trait("Table", "Like")]
	[Trait("Area", "Integration")]
	public class LikeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LikeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLikeModelMapper mapper = new ApiLikeModelMapper();

			UpdateResponse<ApiLikeResponseModel> updateResponse = await this.Client.LikeUpdateAsync(model.LikeId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LikeDeleteAsync(model.LikeId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLikeResponseModel response = await this.Client.LikeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLikeResponseModel> response = await this.Client.LikeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLikeResponseModel> CreateRecord()
		{
			var model = new ApiLikeRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiLikeResponseModel> result = await this.Client.LikeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LikeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a797f8c43ea80a2ae74c314ecc6603f3</Hash>
</Codenesium>*/