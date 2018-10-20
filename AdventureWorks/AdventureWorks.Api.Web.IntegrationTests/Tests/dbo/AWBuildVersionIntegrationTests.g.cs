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
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "Integration")]
	public class AWBuildVersionIntegrationTests
	{
		public AWBuildVersionIntegrationTests()
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

			await client.AWBuildVersionDeleteAsync(1);

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

			ApiAWBuildVersionResponseModel model = await client.AWBuildVersionGetAsync(1);

			ApiAWBuildVersionModelMapper mapper = new ApiAWBuildVersionModelMapper();

			UpdateResponse<ApiAWBuildVersionResponseModel> updateResponse = await client.AWBuildVersionUpdateAsync(model.SystemInformationID, mapper.MapResponseToRequest(model));

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

			ApiAWBuildVersionResponseModel response = await client.AWBuildVersionGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.AWBuildVersionDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.AWBuildVersionGetAsync(1);

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
			ApiAWBuildVersionResponseModel response = await client.AWBuildVersionGetAsync(1);

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

			List<ApiAWBuildVersionResponseModel> response = await client.AWBuildVersionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAWBuildVersionResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiAWBuildVersionRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiAWBuildVersionResponseModel> result = await client.AWBuildVersionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>b10492498ae897087d87feeeedffe360</Hash>
</Codenesium>*/