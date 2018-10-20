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
	[Trait("Table", "Illustration")]
	[Trait("Area", "Integration")]
	public class IllustrationIntegrationTests
	{
		public IllustrationIntegrationTests()
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

			await client.IllustrationDeleteAsync(1);

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

			ApiIllustrationResponseModel model = await client.IllustrationGetAsync(1);

			ApiIllustrationModelMapper mapper = new ApiIllustrationModelMapper();

			UpdateResponse<ApiIllustrationResponseModel> updateResponse = await client.IllustrationUpdateAsync(model.IllustrationID, mapper.MapResponseToRequest(model));

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

			ApiIllustrationResponseModel response = await client.IllustrationGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.IllustrationDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.IllustrationGetAsync(1);

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
			ApiIllustrationResponseModel response = await client.IllustrationGetAsync(1);

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

			List<ApiIllustrationResponseModel> response = await client.IllustrationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiIllustrationResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiIllustrationRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiIllustrationResponseModel> result = await client.IllustrationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>07d7b4ce91e206b2864439cb9ef208ef</Hash>
</Codenesium>*/