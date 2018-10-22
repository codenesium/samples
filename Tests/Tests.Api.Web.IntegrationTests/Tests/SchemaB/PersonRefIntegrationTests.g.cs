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

			var createModel = new ApiPersonRefRequestModel();
			createModel.SetProperties(2, 2);
			CreateResponse<ApiPersonRefResponseModel> createResult = await client.PersonRefCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPersonRefResponseModel getResponse = await client.PersonRefGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PersonRefDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPersonRefResponseModel verifyResponse = await client.PersonRefGetAsync(2);

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
    <Hash>b122a15e2ccc7ebbcd04088ebbc2fab3</Hash>
</Codenesium>*/