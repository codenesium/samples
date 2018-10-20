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
	[Trait("Table", "BusinessEntityContact")]
	[Trait("Area", "Integration")]
	public class BusinessEntityContactIntegrationTests
	{
		public BusinessEntityContactIntegrationTests()
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

			await client.BusinessEntityContactDeleteAsync(1);

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

			ApiBusinessEntityContactResponseModel model = await client.BusinessEntityContactGetAsync(1);

			ApiBusinessEntityContactModelMapper mapper = new ApiBusinessEntityContactModelMapper();

			UpdateResponse<ApiBusinessEntityContactResponseModel> updateResponse = await client.BusinessEntityContactUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiBusinessEntityContactResponseModel response = await client.BusinessEntityContactGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.BusinessEntityContactDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.BusinessEntityContactGetAsync(1);

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
			ApiBusinessEntityContactResponseModel response = await client.BusinessEntityContactGetAsync(1);

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

			List<ApiBusinessEntityContactResponseModel> response = await client.BusinessEntityContactAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBusinessEntityContactResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiBusinessEntityContactRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiBusinessEntityContactResponseModel> result = await client.BusinessEntityContactCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>5dc26feb067b4f7d364a501c0c987053</Hash>
</Codenesium>*/