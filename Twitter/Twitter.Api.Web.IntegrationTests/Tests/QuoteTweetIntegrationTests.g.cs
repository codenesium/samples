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
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "Integration")]
	public class QuoteTweetIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public QuoteTweetIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiQuoteTweetModelMapper mapper = new ApiQuoteTweetModelMapper();

			UpdateResponse<ApiQuoteTweetResponseModel> updateResponse = await this.Client.QuoteTweetUpdateAsync(model.QuoteTweetId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.QuoteTweetDeleteAsync(model.QuoteTweetId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiQuoteTweetResponseModel response = await this.Client.QuoteTweetGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiQuoteTweetResponseModel> response = await this.Client.QuoteTweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiQuoteTweetResponseModel> CreateRecord()
		{
			var model = new ApiQuoteTweetRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("1"));
			CreateResponse<ApiQuoteTweetResponseModel> result = await this.Client.QuoteTweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.QuoteTweetDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>6177b28967a76ed992db21d265dc46af</Hash>
</Codenesium>*/