using FileServiceNS.Api.Client;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "Integration")]
	public class BucketIntegrationTests
	{
		public BucketIntegrationTests()
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

			await client.BucketDeleteAsync(1);

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

			ApiBucketResponseModel model = await client.BucketGetAsync(1);

			ApiBucketModelMapper mapper = new ApiBucketModelMapper();

			UpdateResponse<ApiBucketResponseModel> updateResponse = await client.BucketUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiBucketRequestModel();
			createModel.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiBucketResponseModel> createResult = await client.BucketCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiBucketResponseModel getResponse = await client.BucketGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.BucketDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiBucketResponseModel verifyResponse = await client.BucketGetAsync(2);

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
			ApiBucketResponseModel response = await client.BucketGetAsync(1);

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

			List<ApiBucketResponseModel> response = await client.BucketAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBucketResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiBucketRequestModel();
			model.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiBucketResponseModel> result = await client.BucketCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>89805f47e3c714f4f9b13d81ca9f20dd</Hash>
</Codenesium>*/