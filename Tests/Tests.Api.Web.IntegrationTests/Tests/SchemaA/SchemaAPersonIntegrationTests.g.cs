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
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "Integration")]
	public class SchemaAPersonIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SchemaAPersonIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSchemaAPersonModelMapper mapper = new ApiSchemaAPersonModelMapper();

			UpdateResponse<ApiSchemaAPersonResponseModel> updateResponse = await this.Client.SchemaAPersonUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SchemaAPersonDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSchemaAPersonResponseModel response = await this.Client.SchemaAPersonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSchemaAPersonResponseModel> response = await this.Client.SchemaAPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSchemaAPersonResponseModel> CreateRecord()
		{
			var model = new ApiSchemaAPersonRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiSchemaAPersonResponseModel> result = await this.Client.SchemaAPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SchemaAPersonDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>fc0ed355c247c48b3faa156483b819d7</Hash>
</Codenesium>*/