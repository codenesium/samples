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
	[Trait("Table", "Tweet")]
	[Trait("Area", "Integration")]
	public class TweetIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TweetIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTweetModelMapper mapper = new ApiTweetModelMapper();

			UpdateResponse<ApiTweetResponseModel> updateResponse = await this.Client.TweetUpdateAsync(model.TweetId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TweetDeleteAsync(model.TweetId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTweetResponseModel response = await this.Client.TweetGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTweetResponseModel> response = await this.Client.TweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTweetResponseModel> CreateRecord()
		{
			var model = new ApiTweetRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"), 1);
			CreateResponse<ApiTweetResponseModel> result = await this.Client.TweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TweetDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>b1830ea11c5d2c4a1991aa8797fc5f7b</Hash>
</Codenesium>*/