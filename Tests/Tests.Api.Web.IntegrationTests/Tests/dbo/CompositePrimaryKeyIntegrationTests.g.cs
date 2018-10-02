using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "Integration")]
	public class CompositePrimaryKeyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CompositePrimaryKeyIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCompositePrimaryKeyModelMapper mapper = new ApiCompositePrimaryKeyModelMapper();

			UpdateResponse<ApiCompositePrimaryKeyResponseModel> updateResponse = await this.Client.CompositePrimaryKeyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CompositePrimaryKeyDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCompositePrimaryKeyResponseModel response = await this.Client.CompositePrimaryKeyGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCompositePrimaryKeyResponseModel> response = await this.Client.CompositePrimaryKeyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCompositePrimaryKeyResponseModel> CreateRecord()
		{
			var model = new ApiCompositePrimaryKeyRequestModel();
			model.SetProperties(2);
			CreateResponse<ApiCompositePrimaryKeyResponseModel> result = await this.Client.CompositePrimaryKeyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CompositePrimaryKeyDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>fe72c6015e25f1d9d1ec20c8539f2653</Hash>
</Codenesium>*/