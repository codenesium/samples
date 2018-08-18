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
	[Trait("Table", "PostLinks")]
	[Trait("Area", "Integration")]
	public class PostLinksIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PostLinksIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPostLinksModelMapper mapper = new ApiPostLinksModelMapper();

			UpdateResponse<ApiPostLinksResponseModel> updateResponse = await this.Client.PostLinksUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PostLinksDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPostLinksResponseModel response = await this.Client.PostLinksGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPostLinksResponseModel> response = await this.Client.PostLinksAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostLinksResponseModel> CreateRecord()
		{
			var model = new ApiPostLinksRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiPostLinksResponseModel> result = await this.Client.PostLinksCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PostLinksDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a4ea273b26b82bc4ced88a7beb805ab6</Hash>
</Codenesium>*/