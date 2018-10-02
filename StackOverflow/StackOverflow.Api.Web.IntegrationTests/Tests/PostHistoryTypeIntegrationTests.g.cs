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
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "Integration")]
	public class PostHistoryTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PostHistoryTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPostHistoryTypeModelMapper mapper = new ApiPostHistoryTypeModelMapper();

			UpdateResponse<ApiPostHistoryTypeResponseModel> updateResponse = await this.Client.PostHistoryTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PostHistoryTypeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPostHistoryTypeResponseModel response = await this.Client.PostHistoryTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPostHistoryTypeResponseModel> response = await this.Client.PostHistoryTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostHistoryTypeResponseModel> CreateRecord()
		{
			var model = new ApiPostHistoryTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPostHistoryTypeResponseModel> result = await this.Client.PostHistoryTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PostHistoryTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>aa8b62133ced9394006722f56ab08980</Hash>
</Codenesium>*/