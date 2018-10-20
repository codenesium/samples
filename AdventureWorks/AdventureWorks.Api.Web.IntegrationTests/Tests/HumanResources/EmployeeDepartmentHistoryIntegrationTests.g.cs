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
	[Trait("Table", "EmployeeDepartmentHistory")]
	[Trait("Area", "Integration")]
	public class EmployeeDepartmentHistoryIntegrationTests
	{
		public EmployeeDepartmentHistoryIntegrationTests()
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

			await client.EmployeeDepartmentHistoryDeleteAsync(1);

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

			ApiEmployeeDepartmentHistoryResponseModel model = await client.EmployeeDepartmentHistoryGetAsync(1);

			ApiEmployeeDepartmentHistoryModelMapper mapper = new ApiEmployeeDepartmentHistoryModelMapper();

			UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel> updateResponse = await client.EmployeeDepartmentHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiEmployeeDepartmentHistoryResponseModel response = await client.EmployeeDepartmentHistoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.EmployeeDepartmentHistoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.EmployeeDepartmentHistoryGetAsync(1);

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
			ApiEmployeeDepartmentHistoryResponseModel response = await client.EmployeeDepartmentHistoryGetAsync(1);

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

			List<ApiEmployeeDepartmentHistoryResponseModel> response = await client.EmployeeDepartmentHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEmployeeDepartmentHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEmployeeDepartmentHistoryRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await client.EmployeeDepartmentHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>fafcfe747df7971abc4409c8b98b422a</Hash>
</Codenesium>*/