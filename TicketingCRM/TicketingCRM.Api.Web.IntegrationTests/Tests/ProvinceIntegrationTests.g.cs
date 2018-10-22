using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Province")]
	[Trait("Area", "Integration")]
	public class ProvinceIntegrationTests
	{
		public ProvinceIntegrationTests()
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

			await client.ProvinceDeleteAsync(1);

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

			ApiProvinceResponseModel model = await client.ProvinceGetAsync(1);

			ApiProvinceModelMapper mapper = new ApiProvinceModelMapper();

			UpdateResponse<ApiProvinceResponseModel> updateResponse = await client.ProvinceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiProvinceRequestModel();
			createModel.SetProperties(1, "B");
			CreateResponse<ApiProvinceResponseModel> createResult = await client.ProvinceCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiProvinceResponseModel getResponse = await client.ProvinceGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.ProvinceDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiProvinceResponseModel verifyResponse = await client.ProvinceGetAsync(2);

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
			ApiProvinceResponseModel response = await client.ProvinceGetAsync(1);

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

			List<ApiProvinceResponseModel> response = await client.ProvinceAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProvinceResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProvinceRequestModel();
			model.SetProperties(1, "B");
			CreateResponse<ApiProvinceResponseModel> result = await client.ProvinceCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>58823364654d61ada9deb70a7674486b</Hash>
</Codenesium>*/