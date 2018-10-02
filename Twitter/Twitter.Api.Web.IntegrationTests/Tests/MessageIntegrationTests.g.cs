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
	[Trait("Table", "Message")]
	[Trait("Area", "Integration")]
	public class MessageIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public MessageIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiMessageModelMapper mapper = new ApiMessageModelMapper();

			UpdateResponse<ApiMessageResponseModel> updateResponse = await this.Client.MessageUpdateAsync(model.MessageId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.MessageDeleteAsync(model.MessageId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiMessageResponseModel response = await this.Client.MessageGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiMessageResponseModel> response = await this.Client.MessageAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMessageResponseModel> CreateRecord()
		{
			var model = new ApiMessageRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiMessageResponseModel> result = await this.Client.MessageCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.MessageDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a2daa9bd1719511ad765b2bccbbd68ce</Hash>
</Codenesium>*/