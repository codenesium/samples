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
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "Integration")]
	public class UnitMeasureIntegrationTests
	{
		public UnitMeasureIntegrationTests()
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

			await client.UnitMeasureDeleteAsync("A");

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

			ApiUnitMeasureResponseModel model = await client.UnitMeasureGetAsync("A");

			ApiUnitMeasureModelMapper mapper = new ApiUnitMeasureModelMapper();

			UpdateResponse<ApiUnitMeasureResponseModel> updateResponse = await client.UnitMeasureUpdateAsync(model.UnitMeasureCode, mapper.MapResponseToRequest(model));

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

			ApiUnitMeasureResponseModel response = await client.UnitMeasureGetAsync("A");

			response.Should().NotBeNull();

			ActionResponse result = await client.UnitMeasureDeleteAsync("A");

			result.Success.Should().BeTrue();

			response = await client.UnitMeasureGetAsync("A");

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
			ApiUnitMeasureResponseModel response = await client.UnitMeasureGetAsync("A");

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

			List<ApiUnitMeasureResponseModel> response = await client.UnitMeasureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiUnitMeasureResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiUnitMeasureRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiUnitMeasureResponseModel> result = await client.UnitMeasureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>b8a16492da2eac439f004811b00a26fa</Hash>
</Codenesium>*/