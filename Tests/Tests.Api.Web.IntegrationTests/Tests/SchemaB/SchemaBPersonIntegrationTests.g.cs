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
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "Integration")]
	public class SchemaBPersonIntegrationTests
	{
		public SchemaBPersonIntegrationTests()
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

			await client.SchemaBPersonDeleteAsync(1);

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

			ApiSchemaBPersonResponseModel model = await client.SchemaBPersonGetAsync(1);

			ApiSchemaBPersonModelMapper mapper = new ApiSchemaBPersonModelMapper();

			UpdateResponse<ApiSchemaBPersonResponseModel> updateResponse = await client.SchemaBPersonUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiSchemaBPersonRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiSchemaBPersonResponseModel> createResult = await client.SchemaBPersonCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiSchemaBPersonResponseModel getResponse = await client.SchemaBPersonGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.SchemaBPersonDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiSchemaBPersonResponseModel verifyResponse = await client.SchemaBPersonGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSchemaBPersonResponseModel response = await client.SchemaBPersonGetAsync(1);

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

			List<ApiSchemaBPersonResponseModel> response = await client.SchemaBPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSchemaBPersonResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSchemaBPersonRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiSchemaBPersonResponseModel> result = await client.SchemaBPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>7821c33b3160038b995108735f7ff090</Hash>
</Codenesium>*/