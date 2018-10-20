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
	[Trait("Table", "SelfReference")]
	[Trait("Area", "Integration")]
	public class SelfReferenceIntegrationTests
	{
		public SelfReferenceIntegrationTests()
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

			await client.SelfReferenceDeleteAsync(1);

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

			ApiSelfReferenceResponseModel model = await client.SelfReferenceGetAsync(1);

			ApiSelfReferenceModelMapper mapper = new ApiSelfReferenceModelMapper();

			UpdateResponse<ApiSelfReferenceResponseModel> updateResponse = await client.SelfReferenceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiSelfReferenceResponseModel response = await client.SelfReferenceGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SelfReferenceDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SelfReferenceGetAsync(1);

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
			ApiSelfReferenceResponseModel response = await client.SelfReferenceGetAsync(1);

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

			List<ApiSelfReferenceResponseModel> response = await client.SelfReferenceAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSelfReferenceResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSelfReferenceRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiSelfReferenceResponseModel> result = await client.SelfReferenceCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>60b7a3e4cb4bbb094b62e89083787b4b</Hash>
</Codenesium>*/