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
	[Trait("Table", "LinkType")]
	[Trait("Area", "Integration")]
	public class LinkTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LinkTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLinkTypeModelMapper mapper = new ApiLinkTypeModelMapper();

			UpdateResponse<ApiLinkTypeResponseModel> updateResponse = await this.Client.LinkTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LinkTypeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLinkTypeResponseModel response = await this.Client.LinkTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLinkTypeResponseModel> response = await this.Client.LinkTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLinkTypeResponseModel> CreateRecord()
		{
			var model = new ApiLinkTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiLinkTypeResponseModel> result = await this.Client.LinkTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LinkTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>31b6da68c7f01a94adde93ae8b53ebaf</Hash>
</Codenesium>*/