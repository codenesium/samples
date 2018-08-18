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
	[Trait("Table", "Badges")]
	[Trait("Area", "Integration")]
	public class BadgesIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public BadgesIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiBadgesModelMapper mapper = new ApiBadgesModelMapper();

			UpdateResponse<ApiBadgesResponseModel> updateResponse = await this.Client.BadgesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.BadgesDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiBadgesResponseModel response = await this.Client.BadgesGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiBadgesResponseModel> response = await this.Client.BadgesAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBadgesResponseModel> CreateRecord()
		{
			var model = new ApiBadgesRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2);
			CreateResponse<ApiBadgesResponseModel> result = await this.Client.BadgesCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.BadgesDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>6d76937b5b1be09fd47003baed8afa3f</Hash>
</Codenesium>*/