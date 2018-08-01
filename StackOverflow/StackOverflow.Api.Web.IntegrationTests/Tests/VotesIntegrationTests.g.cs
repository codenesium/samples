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
	[Trait("Table", "Votes")]
	[Trait("Area", "Integration")]
	public class VotesIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VotesIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVotesModelMapper mapper = new ApiVotesModelMapper();

			UpdateResponse<ApiVotesResponseModel> updateResponse = await this.Client.VotesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VotesDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVotesResponseModel response = await this.Client.VotesGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVotesResponseModel> response = await this.Client.VotesAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVotesResponseModel> CreateRecord()
		{
			var model = new ApiVotesRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiVotesResponseModel> result = await this.Client.VotesCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VotesDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>04175950e0e513d4039ec76eb6b1531d</Hash>
</Codenesium>*/