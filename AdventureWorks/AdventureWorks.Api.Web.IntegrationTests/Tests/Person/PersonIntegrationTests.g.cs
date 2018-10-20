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
	[Trait("Table", "Person")]
	[Trait("Area", "Integration")]
	public class PersonIntegrationTests
	{
		public PersonIntegrationTests()
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

			await client.PersonDeleteAsync(1);

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

			ApiPersonResponseModel model = await client.PersonGetAsync(1);

			ApiPersonModelMapper mapper = new ApiPersonModelMapper();

			UpdateResponse<ApiPersonResponseModel> updateResponse = await client.PersonUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiPersonResponseModel response = await client.PersonGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PersonDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PersonGetAsync(1);

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
			ApiPersonResponseModel response = await client.PersonGetAsync(1);

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

			List<ApiPersonResponseModel> response = await client.PersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPersonResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPersonRequestModel();
			model.SetProperties("B", "B", 2, "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", "B");
			CreateResponse<ApiPersonResponseModel> result = await client.PersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ea270ea9fa40d95ef009842fbb65b083</Hash>
</Codenesium>*/