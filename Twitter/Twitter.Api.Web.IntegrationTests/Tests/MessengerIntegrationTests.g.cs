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
	[Trait("Table", "Messenger")]
	[Trait("Area", "Integration")]
	public class MessengerIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public MessengerIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiMessengerModelMapper mapper = new ApiMessengerModelMapper();

			UpdateResponse<ApiMessengerResponseModel> updateResponse = await this.Client.MessengerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.MessengerDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiMessengerResponseModel response = await this.Client.MessengerGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiMessengerResponseModel> response = await this.Client.MessengerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMessengerResponseModel> CreateRecord()
		{
			var model = new ApiMessengerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("1"), 1, 1);
			CreateResponse<ApiMessengerResponseModel> result = await this.Client.MessengerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.MessengerDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>1c3fe5e2c106e4f9dfe0a800c306b586</Hash>
</Codenesium>*/