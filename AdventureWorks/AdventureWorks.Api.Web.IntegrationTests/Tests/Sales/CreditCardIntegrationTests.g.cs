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
	[Trait("Table", "CreditCard")]
	[Trait("Area", "Integration")]
	public class CreditCardIntegrationTests
	{
		public CreditCardIntegrationTests()
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

			await client.CreditCardDeleteAsync(1);

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

			ApiCreditCardResponseModel model = await client.CreditCardGetAsync(1);

			ApiCreditCardModelMapper mapper = new ApiCreditCardModelMapper();

			UpdateResponse<ApiCreditCardResponseModel> updateResponse = await client.CreditCardUpdateAsync(model.CreditCardID, mapper.MapResponseToRequest(model));

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

			ApiCreditCardResponseModel response = await client.CreditCardGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.CreditCardDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.CreditCardGetAsync(1);

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
			ApiCreditCardResponseModel response = await client.CreditCardGetAsync(1);

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

			List<ApiCreditCardResponseModel> response = await client.CreditCardAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCreditCardResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCreditCardRequestModel();
			model.SetProperties("B", "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiCreditCardResponseModel> result = await client.CreditCardCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>b6994280fbe351fdd56ca022958ac15f</Hash>
</Codenesium>*/