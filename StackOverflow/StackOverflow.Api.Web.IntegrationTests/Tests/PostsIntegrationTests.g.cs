using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Posts")]
	[Trait("Area", "Integration")]
	public class PostsIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PostsIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPostsModelMapper mapper = new ApiPostsModelMapper();

			UpdateResponse<ApiPostsResponseModel> updateResponse = await this.Client.PostsUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PostsDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPostsResponseModel response = await this.Client.PostsGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPostsResponseModel> response = await this.Client.PostsAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostsResponseModel> CreateRecord()
		{
			var model = new ApiPostsRequestModel();
			model.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, 2, 2, "B", "B", 2);
			CreateResponse<ApiPostsResponseModel> result = await this.Client.PostsCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PostsDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>1e2c518a6ec9f9cb2089e58caf729362</Hash>
</Codenesium>*/