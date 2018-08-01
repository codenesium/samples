using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "SchemaVersions")]
	[Trait("Area", "Integration")]
	public class SchemaVersionsIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SchemaVersionsIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSchemaVersionsModelMapper mapper = new ApiSchemaVersionsModelMapper();

			UpdateResponse<ApiSchemaVersionsResponseModel> updateResponse = await this.Client.SchemaVersionsUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SchemaVersionsDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSchemaVersionsResponseModel response = await this.Client.SchemaVersionsGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSchemaVersionsResponseModel> response = await this.Client.SchemaVersionsAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSchemaVersionsResponseModel> CreateRecord()
		{
			var model = new ApiSchemaVersionsRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiSchemaVersionsResponseModel> result = await this.Client.SchemaVersionsCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SchemaVersionsDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>1f1e06c29e1ea6ec00927c2570c9bcea</Hash>
</Codenesium>*/