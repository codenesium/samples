using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "Integration")]
	public class BillOfMaterialIntegrationTests
	{
		public BillOfMaterialIntegrationTests()
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

			await client.BillOfMaterialDeleteAsync(1);

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

			ApiBillOfMaterialResponseModel model = await client.BillOfMaterialGetAsync(1);

			ApiBillOfMaterialModelMapper mapper = new ApiBillOfMaterialModelMapper();

			UpdateResponse<ApiBillOfMaterialResponseModel> updateResponse = await client.BillOfMaterialUpdateAsync(model.BillOfMaterialsID, mapper.MapResponseToRequest(model));

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

			ApiBillOfMaterialResponseModel response = await client.BillOfMaterialGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.BillOfMaterialDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.BillOfMaterialGetAsync(1);

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
			ApiBillOfMaterialResponseModel response = await client.BillOfMaterialGetAsync(1);

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

			List<ApiBillOfMaterialResponseModel> response = await client.BillOfMaterialAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBillOfMaterialResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiBillOfMaterialRequestModel();
			model.SetProperties(2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiBillOfMaterialResponseModel> result = await client.BillOfMaterialCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>1b056b6705e9c8769dfedbbdbe3eadf5</Hash>
</Codenesium>*/