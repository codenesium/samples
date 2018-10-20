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
	[Trait("Table", "EmployeePayHistory")]
	[Trait("Area", "Integration")]
	public class EmployeePayHistoryIntegrationTests
	{
		public EmployeePayHistoryIntegrationTests()
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

			await client.EmployeePayHistoryDeleteAsync(1);

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

			ApiEmployeePayHistoryResponseModel model = await client.EmployeePayHistoryGetAsync(1);

			ApiEmployeePayHistoryModelMapper mapper = new ApiEmployeePayHistoryModelMapper();

			UpdateResponse<ApiEmployeePayHistoryResponseModel> updateResponse = await client.EmployeePayHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiEmployeePayHistoryResponseModel response = await client.EmployeePayHistoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.EmployeePayHistoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.EmployeePayHistoryGetAsync(1);

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
			ApiEmployeePayHistoryResponseModel response = await client.EmployeePayHistoryGetAsync(1);

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

			List<ApiEmployeePayHistoryResponseModel> response = await client.EmployeePayHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEmployeePayHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEmployeePayHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiEmployeePayHistoryResponseModel> result = await client.EmployeePayHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>cfa8eeeb65c4ab3be4ae6f3a6118ae63</Hash>
</Codenesium>*/