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
	[Trait("Table", "Tag")]
	[Trait("Area", "Integration")]
	public class TagIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TagIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTagModelMapper mapper = new ApiTagModelMapper();

			UpdateResponse<ApiTagResponseModel> updateResponse = await this.Client.TagUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TagDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTagResponseModel response = await this.Client.TagGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTagResponseModel> response = await this.Client.TagAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTagResponseModel> CreateRecord()
		{
			var model = new ApiTagRequestModel();
			model.SetProperties(2, 2, "B", 2);
			CreateResponse<ApiTagResponseModel> result = await this.Client.TagCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TagDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>1450a94461b04ce147bfeb703966a89d</Hash>
</Codenesium>*/