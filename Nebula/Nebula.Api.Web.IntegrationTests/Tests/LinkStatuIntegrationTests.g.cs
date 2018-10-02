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
	[Trait("Table", "LinkStatu")]
	[Trait("Area", "Integration")]
	public class LinkStatuIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LinkStatuIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLinkStatuModelMapper mapper = new ApiLinkStatuModelMapper();

			UpdateResponse<ApiLinkStatuResponseModel> updateResponse = await this.Client.LinkStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LinkStatuDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLinkStatuResponseModel response = await this.Client.LinkStatuGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLinkStatuResponseModel> response = await this.Client.LinkStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLinkStatuResponseModel> CreateRecord()
		{
			var model = new ApiLinkStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiLinkStatuResponseModel> result = await this.Client.LinkStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LinkStatuDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>210441ba326b95972b0399c3e912573a</Hash>
</Codenesium>*/