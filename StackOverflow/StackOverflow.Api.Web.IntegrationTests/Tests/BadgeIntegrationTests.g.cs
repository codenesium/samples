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
	[Trait("Table", "Badge")]
	[Trait("Area", "Integration")]
	public class BadgeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public BadgeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiBadgeModelMapper mapper = new ApiBadgeModelMapper();

			UpdateResponse<ApiBadgeResponseModel> updateResponse = await this.Client.BadgeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.BadgeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiBadgeResponseModel response = await this.Client.BadgeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiBadgeResponseModel> response = await this.Client.BadgeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBadgeResponseModel> CreateRecord()
		{
			var model = new ApiBadgeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2);
			CreateResponse<ApiBadgeResponseModel> result = await this.Client.BadgeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.BadgeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>44b597f52d79d48f027f67c7ffe3ca4d</Hash>
</Codenesium>*/