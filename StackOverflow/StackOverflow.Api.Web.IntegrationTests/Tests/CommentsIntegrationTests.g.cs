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
	[Trait("Table", "Comments")]
	[Trait("Area", "Integration")]
	public class CommentsIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CommentsIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCommentsModelMapper mapper = new ApiCommentsModelMapper();

			UpdateResponse<ApiCommentsResponseModel> updateResponse = await this.Client.CommentsUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CommentsDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCommentsResponseModel response = await this.Client.CommentsGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCommentsResponseModel> response = await this.Client.CommentsAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCommentsResponseModel> CreateRecord()
		{
			var model = new ApiCommentsRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);
			CreateResponse<ApiCommentsResponseModel> result = await this.Client.CommentsCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CommentsDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>6007f575c9082bd4a48d26706adcaade</Hash>
</Codenesium>*/