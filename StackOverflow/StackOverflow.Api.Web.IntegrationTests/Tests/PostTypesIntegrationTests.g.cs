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
	[Trait("Table", "PostTypes")]
	[Trait("Area", "Integration")]
	public class PostTypesIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PostTypesIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPostTypesModelMapper mapper = new ApiPostTypesModelMapper();

			UpdateResponse<ApiPostTypesResponseModel> updateResponse = await this.Client.PostTypesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PostTypesDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPostTypesResponseModel response = await this.Client.PostTypesGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPostTypesResponseModel> response = await this.Client.PostTypesAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostTypesResponseModel> CreateRecord()
		{
			var model = new ApiPostTypesRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPostTypesResponseModel> result = await this.Client.PostTypesCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PostTypesDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a9d6fbca89a5ecf20b0718c4ad3a7676</Hash>
</Codenesium>*/