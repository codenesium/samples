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
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "Integration")]
	public class DirectTweetIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public DirectTweetIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiDirectTweetModelMapper mapper = new ApiDirectTweetModelMapper();

			UpdateResponse<ApiDirectTweetResponseModel> updateResponse = await this.Client.DirectTweetUpdateAsync(model.TweetId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.DirectTweetDeleteAsync(model.TweetId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiDirectTweetResponseModel response = await this.Client.DirectTweetGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiDirectTweetResponseModel> response = await this.Client.DirectTweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDirectTweetResponseModel> CreateRecord()
		{
			var model = new ApiDirectTweetRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"));
			CreateResponse<ApiDirectTweetResponseModel> result = await this.Client.DirectTweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.DirectTweetDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>74ab26f85811eed83f296efd6e164ccb</Hash>
</Codenesium>*/