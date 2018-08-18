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
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "Integration")]
	public class VoteTypesIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VoteTypesIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVoteTypesModelMapper mapper = new ApiVoteTypesModelMapper();

			UpdateResponse<ApiVoteTypesResponseModel> updateResponse = await this.Client.VoteTypesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VoteTypesDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVoteTypesResponseModel response = await this.Client.VoteTypesGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVoteTypesResponseModel> response = await this.Client.VoteTypesAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVoteTypesResponseModel> CreateRecord()
		{
			var model = new ApiVoteTypesRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiVoteTypesResponseModel> result = await this.Client.VoteTypesCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VoteTypesDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>28f8a2d3cb07bd78534b032c593dc1b4</Hash>
</Codenesium>*/