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
	[Trait("Table", "Employee")]
	[Trait("Area", "Integration")]
	public class EmployeeIntegrationTests
	{
		public EmployeeIntegrationTests()
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

			await client.EmployeeDeleteAsync(1);

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

			ApiEmployeeResponseModel model = await client.EmployeeGetAsync(1);

			ApiEmployeeModelMapper mapper = new ApiEmployeeModelMapper();

			UpdateResponse<ApiEmployeeResponseModel> updateResponse = await client.EmployeeUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiEmployeeResponseModel response = await client.EmployeeGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.EmployeeDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.EmployeeGetAsync(1);

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
			ApiEmployeeResponseModel response = await client.EmployeeGetAsync(1);

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

			List<ApiEmployeeResponseModel> response = await client.EmployeeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEmployeeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEmployeeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			CreateResponse<ApiEmployeeResponseModel> result = await client.EmployeeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>aff4096716c2f58fba7dbe5428a9cf51</Hash>
</Codenesium>*/