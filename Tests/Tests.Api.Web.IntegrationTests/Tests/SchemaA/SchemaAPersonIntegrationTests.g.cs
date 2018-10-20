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
	public class SchemaAPersonIntegrationTests
	{
		public SchemaAPersonIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.SchemaAPersonDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiSchemaAPersonResponseModel model = await client.SchemaAPersonGetAsync(1);

			ApiSchemaAPersonModelMapper mapper = new ApiSchemaAPersonModelMapper();

			UpdateResponse<ApiSchemaAPersonResponseModel> updateResponse = await client.SchemaAPersonUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiSchemaAPersonResponseModel response = await client.SchemaAPersonGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SchemaAPersonDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SchemaAPersonGetAsync(1);

			response.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSchemaAPersonResponseModel response = await client.SchemaAPersonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiSchemaAPersonResponseModel> response = await client.SchemaAPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSchemaAPersonResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSchemaAPersonRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiSchemaAPersonResponseModel> result = await client.SchemaAPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>77f32d5628b56f196a62ec6b8b8f6383</Hash>
</Codenesium>*/