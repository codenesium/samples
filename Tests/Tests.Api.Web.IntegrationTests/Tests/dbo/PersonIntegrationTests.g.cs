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

			UpdateResponse<ApiPersonResponseModel> updateResponse = await client.PersonUpdateAsync(model.PersonId, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPersonRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiPersonResponseModel> createResult = await client.PersonCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPersonResponseModel getResponse = await client.PersonGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PersonDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPersonResponseModel verifyResponse = await client.PersonGetAsync(2);

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
			model.SetProperties("B");
			CreateResponse<ApiPersonResponseModel> result = await client.PersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ef179d177d1cf7fbaba153d9c3ed4fa2</Hash>
</Codenesium>*/