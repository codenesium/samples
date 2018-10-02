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
	[Trait("Table", "Vote")]
	[Trait("Area", "Integration")]
	public class VoteIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VoteIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVoteModelMapper mapper = new ApiVoteModelMapper();

			UpdateResponse<ApiVoteResponseModel> updateResponse = await this.Client.VoteUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VoteDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVoteResponseModel response = await this.Client.VoteGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVoteResponseModel> response = await this.Client.VoteAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVoteResponseModel> CreateRecord()
		{
			var model = new ApiVoteRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiVoteResponseModel> result = await this.Client.VoteCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VoteDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>62d6f4c802fc0753153f3591904d5ddd</Hash>
</Codenesium>*/