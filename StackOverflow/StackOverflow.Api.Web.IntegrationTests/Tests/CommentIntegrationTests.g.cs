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
	[Trait("Table", "Comment")]
	[Trait("Area", "Integration")]
	public class CommentIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CommentIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCommentModelMapper mapper = new ApiCommentModelMapper();

			UpdateResponse<ApiCommentResponseModel> updateResponse = await this.Client.CommentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CommentDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCommentResponseModel response = await this.Client.CommentGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCommentResponseModel> response = await this.Client.CommentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCommentResponseModel> CreateRecord()
		{
			var model = new ApiCommentRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);
			CreateResponse<ApiCommentResponseModel> result = await this.Client.CommentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CommentDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>eeb2f5e1683cdd1f08a6e17628e731b6</Hash>
</Codenesium>*/