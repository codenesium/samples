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
	[Trait("Table", "Following")]
	[Trait("Area", "Integration")]
	public class FollowingIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public FollowingIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiFollowingModelMapper mapper = new ApiFollowingModelMapper();

			UpdateResponse<ApiFollowingResponseModel> updateResponse = await this.Client.FollowingUpdateAsync(model.UserId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.FollowingDeleteAsync(model.UserId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiFollowingResponseModel response = await this.Client.FollowingGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiFollowingResponseModel> response = await this.Client.FollowingAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFollowingResponseModel> CreateRecord()
		{
			var model = new ApiFollowingRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiFollowingResponseModel> result = await this.Client.FollowingCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.FollowingDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>a5d3582faef632b19f4febb6b961e671</Hash>
</Codenesium>*/