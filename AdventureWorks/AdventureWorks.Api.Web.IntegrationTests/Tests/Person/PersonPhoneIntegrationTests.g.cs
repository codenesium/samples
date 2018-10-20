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
	[Trait("Table", "PersonPhone")]
	[Trait("Area", "Integration")]
	public class PersonPhoneIntegrationTests
	{
		public PersonPhoneIntegrationTests()
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

			await client.PersonPhoneDeleteAsync(1);

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

			ApiPersonPhoneResponseModel model = await client.PersonPhoneGetAsync(1);

			ApiPersonPhoneModelMapper mapper = new ApiPersonPhoneModelMapper();

			UpdateResponse<ApiPersonPhoneResponseModel> updateResponse = await client.PersonPhoneUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiPersonPhoneResponseModel response = await client.PersonPhoneGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PersonPhoneDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PersonPhoneGetAsync(1);

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
			ApiPersonPhoneResponseModel response = await client.PersonPhoneGetAsync(1);

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

			List<ApiPersonPhoneResponseModel> response = await client.PersonPhoneAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPersonPhoneResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPersonPhoneRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2);
			CreateResponse<ApiPersonPhoneResponseModel> result = await client.PersonPhoneCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>f9050c8bfbf258f5437431fb1f2c4002</Hash>
</Codenesium>*/