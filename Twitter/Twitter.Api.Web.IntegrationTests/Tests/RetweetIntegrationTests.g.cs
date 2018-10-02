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
	[Trait("Table", "Retweet")]
	[Trait("Area", "Integration")]
	public class RetweetIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public RetweetIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiRetweetModelMapper mapper = new ApiRetweetModelMapper();

			UpdateResponse<ApiRetweetResponseModel> updateResponse = await this.Client.RetweetUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.RetweetDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiRetweetResponseModel response = await this.Client.RetweetGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiRetweetResponseModel> response = await this.Client.RetweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiRetweetResponseModel> CreateRecord()
		{
			var model = new ApiRetweetRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"), 1);
			CreateResponse<ApiRetweetResponseModel> result = await this.Client.RetweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.RetweetDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>98dc050d2b06c4dd984ec73a61db31ae</Hash>
</Codenesium>*/