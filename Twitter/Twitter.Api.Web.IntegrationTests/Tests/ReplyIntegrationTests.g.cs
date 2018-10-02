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
	[Trait("Table", "Reply")]
	[Trait("Area", "Integration")]
	public class ReplyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ReplyIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiReplyModelMapper mapper = new ApiReplyModelMapper();

			UpdateResponse<ApiReplyResponseModel> updateResponse = await this.Client.ReplyUpdateAsync(model.ReplyId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ReplyDeleteAsync(model.ReplyId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiReplyResponseModel response = await this.Client.ReplyGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiReplyResponseModel> response = await this.Client.ReplyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiReplyResponseModel> CreateRecord()
		{
			var model = new ApiReplyRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"));
			CreateResponse<ApiReplyResponseModel> result = await this.Client.ReplyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ReplyDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>846e1813354342cc2671879d32e7bd02</Hash>
</Codenesium>*/