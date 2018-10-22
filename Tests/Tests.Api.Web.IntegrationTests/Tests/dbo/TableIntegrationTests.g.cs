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
	[Trait("Table", "Table")]
	[Trait("Area", "Integration")]
	public class TableIntegrationTests
	{
		public TableIntegrationTests()
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

			await client.TableDeleteAsync(1);

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

			ApiTableResponseModel model = await client.TableGetAsync(1);

			ApiTableModelMapper mapper = new ApiTableModelMapper();

			UpdateResponse<ApiTableResponseModel> updateResponse = await client.TableUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTableRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiTableResponseModel> createResult = await client.TableCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTableResponseModel getResponse = await client.TableGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TableDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTableResponseModel verifyResponse = await client.TableGetAsync(2);

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
			ApiTableResponseModel response = await client.TableGetAsync(1);

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

			List<ApiTableResponseModel> response = await client.TableAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTableResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTableRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTableResponseModel> result = await client.TableCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ec3315ccdc4b2800684db87094c485cf</Hash>
</Codenesium>*/