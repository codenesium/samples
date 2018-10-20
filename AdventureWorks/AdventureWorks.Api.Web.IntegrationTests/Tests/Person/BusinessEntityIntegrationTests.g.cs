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
	[Trait("Table", "BusinessEntity")]
	[Trait("Area", "Integration")]
	public class BusinessEntityIntegrationTests
	{
		public BusinessEntityIntegrationTests()
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

			await client.BusinessEntityDeleteAsync(1);

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

			ApiBusinessEntityResponseModel model = await client.BusinessEntityGetAsync(1);

			ApiBusinessEntityModelMapper mapper = new ApiBusinessEntityModelMapper();

			UpdateResponse<ApiBusinessEntityResponseModel> updateResponse = await client.BusinessEntityUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiBusinessEntityResponseModel response = await client.BusinessEntityGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.BusinessEntityDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.BusinessEntityGetAsync(1);

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
			ApiBusinessEntityResponseModel response = await client.BusinessEntityGetAsync(1);

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

			List<ApiBusinessEntityResponseModel> response = await client.BusinessEntityAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBusinessEntityResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiBusinessEntityRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiBusinessEntityResponseModel> result = await client.BusinessEntityCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>43ab0860cd4dadd72776309f98d8290f</Hash>
</Codenesium>*/