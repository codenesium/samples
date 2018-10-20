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
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "Integration")]
	public class TestAllFieldTypesNullableIntegrationTests
	{
		public TestAllFieldTypesNullableIntegrationTests()
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

			await client.TestAllFieldTypesNullableDeleteAsync(1);

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

			ApiTestAllFieldTypesNullableResponseModel model = await client.TestAllFieldTypesNullableGetAsync(1);

			ApiTestAllFieldTypesNullableModelMapper mapper = new ApiTestAllFieldTypesNullableModelMapper();

			UpdateResponse<ApiTestAllFieldTypesNullableResponseModel> updateResponse = await client.TestAllFieldTypesNullableUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiTestAllFieldTypesNullableResponseModel response = await client.TestAllFieldTypesNullableGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.TestAllFieldTypesNullableDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.TestAllFieldTypesNullableGetAsync(1);

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
			ApiTestAllFieldTypesNullableResponseModel response = await client.TestAllFieldTypesNullableGetAsync(1);

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

			List<ApiTestAllFieldTypesNullableResponseModel> response = await client.TestAllFieldTypesNullableAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTestAllFieldTypesNullableResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTestAllFieldTypesNullableRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("1"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			CreateResponse<ApiTestAllFieldTypesNullableResponseModel> result = await client.TestAllFieldTypesNullableCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>aed629deb0fb3d44b392243b34c22d96</Hash>
</Codenesium>*/