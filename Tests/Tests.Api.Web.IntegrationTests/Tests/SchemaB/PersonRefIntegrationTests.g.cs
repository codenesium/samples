using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "PersonRef")]
	[Trait("Area", "Integration")]
	public class PersonRefIntegrationTests
	{
		public PersonRefIntegrationTests()
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

			await client.PersonRefDeleteAsync(1);

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

			ApiPersonRefResponseModel model = await client.PersonRefGetAsync(1);

			ApiPersonRefModelMapper mapper = new ApiPersonRefModelMapper();

			UpdateResponse<ApiPersonRefResponseModel> updateResponse = await client.PersonRefUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiPersonRefResponseModel response = await client.PersonRefGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PersonRefDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PersonRefGetAsync(1);

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
			ApiPersonRefResponseModel response = await client.PersonRefGetAsync(1);

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

			List<ApiPersonRefResponseModel> response = await client.PersonRefAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPersonRefResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPersonRefRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiPersonRefResponseModel> result = await client.PersonRefCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c1a3a3ef6308b45498114b261091167d</Hash>
</Codenesium>*/