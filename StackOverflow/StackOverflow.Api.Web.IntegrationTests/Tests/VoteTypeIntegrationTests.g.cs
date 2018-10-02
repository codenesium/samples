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
	[Trait("Table", "VoteType")]
	[Trait("Area", "Integration")]
	public class VoteTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VoteTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVoteTypeModelMapper mapper = new ApiVoteTypeModelMapper();

			UpdateResponse<ApiVoteTypeResponseModel> updateResponse = await this.Client.VoteTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VoteTypeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVoteTypeResponseModel response = await this.Client.VoteTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVoteTypeResponseModel> response = await this.Client.VoteTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVoteTypeResponseModel> CreateRecord()
		{
			var model = new ApiVoteTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiVoteTypeResponseModel> result = await this.Client.VoteTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VoteTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>ee1fe4ee8e1db6dbece61d9045d23c2e</Hash>
</Codenesium>*/