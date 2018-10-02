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
	[Trait("Table", "PostType")]
	[Trait("Area", "Integration")]
	public class PostTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PostTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPostTypeModelMapper mapper = new ApiPostTypeModelMapper();

			UpdateResponse<ApiPostTypeResponseModel> updateResponse = await this.Client.PostTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PostTypeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPostTypeResponseModel response = await this.Client.PostTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPostTypeResponseModel> response = await this.Client.PostTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostTypeResponseModel> CreateRecord()
		{
			var model = new ApiPostTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPostTypeResponseModel> result = await this.Client.PostTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PostTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>bbe40f348fef833eb97c5926ae510979</Hash>
</Codenesium>*/