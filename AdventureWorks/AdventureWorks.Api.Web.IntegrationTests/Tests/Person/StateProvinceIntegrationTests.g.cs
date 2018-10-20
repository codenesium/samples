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
	[Trait("Table", "StateProvince")]
	[Trait("Area", "Integration")]
	public class StateProvinceIntegrationTests
	{
		public StateProvinceIntegrationTests()
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

			await client.StateProvinceDeleteAsync(1);

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

			ApiStateProvinceResponseModel model = await client.StateProvinceGetAsync(1);

			ApiStateProvinceModelMapper mapper = new ApiStateProvinceModelMapper();

			UpdateResponse<ApiStateProvinceResponseModel> updateResponse = await client.StateProvinceUpdateAsync(model.StateProvinceID, mapper.MapResponseToRequest(model));

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

			ApiStateProvinceResponseModel response = await client.StateProvinceGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.StateProvinceDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.StateProvinceGetAsync(1);

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
			ApiStateProvinceResponseModel response = await client.StateProvinceGetAsync(1);

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

			List<ApiStateProvinceResponseModel> response = await client.StateProvinceAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStateProvinceResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiStateProvinceRequestModel();
			model.SetProperties("B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 2);
			CreateResponse<ApiStateProvinceResponseModel> result = await client.StateProvinceCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>580730d592756db8678bb5108b6bcefc</Hash>
</Codenesium>*/