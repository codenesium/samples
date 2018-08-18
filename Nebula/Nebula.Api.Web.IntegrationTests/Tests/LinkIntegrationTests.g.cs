using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Link")]
	[Trait("Area", "Integration")]
	public class LinkIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LinkIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLinkModelMapper mapper = new ApiLinkModelMapper();

			UpdateResponse<ApiLinkResponseModel> updateResponse = await this.Client.LinkUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LinkDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLinkResponseModel response = await this.Client.LinkGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLinkResponseModel> response = await this.Client.LinkAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLinkResponseModel> CreateRecord()
		{
			var model = new ApiLinkRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, "B", 2, "B", "B", 2);
			CreateResponse<ApiLinkResponseModel> result = await this.Client.LinkCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LinkDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>b5647ea73e8dcfb97522d44ada5115cd</Hash>
</Codenesium>*/