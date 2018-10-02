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
	[Trait("Table", "PostLink")]
	[Trait("Area", "Integration")]
	public class PostLinkIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PostLinkIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPostLinkModelMapper mapper = new ApiPostLinkModelMapper();

			UpdateResponse<ApiPostLinkResponseModel> updateResponse = await this.Client.PostLinkUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PostLinkDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPostLinkResponseModel response = await this.Client.PostLinkGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPostLinkResponseModel> response = await this.Client.PostLinkAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostLinkResponseModel> CreateRecord()
		{
			var model = new ApiPostLinkRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiPostLinkResponseModel> result = await this.Client.PostLinkCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PostLinkDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>dcb9b67acbb5624b1a6c222e958d1e30</Hash>
</Codenesium>*/