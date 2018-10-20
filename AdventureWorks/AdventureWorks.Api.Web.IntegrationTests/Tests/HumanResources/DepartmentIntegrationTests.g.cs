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
	[Trait("Table", "Department")]
	[Trait("Area", "Integration")]
	public class DepartmentIntegrationTests
	{
		public DepartmentIntegrationTests()
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

			await client.DepartmentDeleteAsync(1);

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

			ApiDepartmentResponseModel model = await client.DepartmentGetAsync(1);

			ApiDepartmentModelMapper mapper = new ApiDepartmentModelMapper();

			UpdateResponse<ApiDepartmentResponseModel> updateResponse = await client.DepartmentUpdateAsync(model.DepartmentID, mapper.MapResponseToRequest(model));

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

			ApiDepartmentResponseModel response = await client.DepartmentGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.DepartmentDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.DepartmentGetAsync(1);

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
			ApiDepartmentResponseModel response = await client.DepartmentGetAsync(1);

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

			List<ApiDepartmentResponseModel> response = await client.DepartmentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDepartmentResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiDepartmentRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiDepartmentResponseModel> result = await client.DepartmentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>610b97f866994047f8422a6e4116d15c</Hash>
</Codenesium>*/