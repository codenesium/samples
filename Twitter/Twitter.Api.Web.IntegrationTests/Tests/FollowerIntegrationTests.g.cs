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
	[Trait("Table", "Follower")]
	[Trait("Area", "Integration")]
	public class FollowerIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public FollowerIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiFollowerModelMapper mapper = new ApiFollowerModelMapper();

			UpdateResponse<ApiFollowerResponseModel> updateResponse = await this.Client.FollowerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.FollowerDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiFollowerResponseModel response = await this.Client.FollowerGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiFollowerResponseModel> response = await this.Client.FollowerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFollowerResponseModel> CreateRecord()
		{
			var model = new ApiFollowerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, "B");
			CreateResponse<ApiFollowerResponseModel> result = await this.Client.FollowerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.FollowerDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>516e0b5715227d905c10f5b6c6a44146</Hash>
</Codenesium>*/