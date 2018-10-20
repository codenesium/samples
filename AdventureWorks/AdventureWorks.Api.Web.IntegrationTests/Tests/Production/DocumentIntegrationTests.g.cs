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
	[Trait("Table", "Document")]
	[Trait("Area", "Integration")]
	public class DocumentIntegrationTests
	{
		public DocumentIntegrationTests()
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

			await client.DocumentDeleteAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

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

			ApiDocumentResponseModel model = await client.DocumentGetAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			ApiDocumentModelMapper mapper = new ApiDocumentModelMapper();

			UpdateResponse<ApiDocumentResponseModel> updateResponse = await client.DocumentUpdateAsync(model.Rowguid, mapper.MapResponseToRequest(model));

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

			ApiDocumentResponseModel response = await client.DocumentGetAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			ActionResponse result = await client.DocumentDeleteAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			result.Success.Should().BeTrue();

			response = await client.DocumentGetAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

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
			ApiDocumentResponseModel response = await client.DocumentGetAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

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

			List<ApiDocumentResponseModel> response = await client.DocumentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDocumentResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiDocumentRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", 2, "B");
			CreateResponse<ApiDocumentResponseModel> result = await client.DocumentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>e3b1c386d5f0c9828744867c123e95d2</Hash>
</Codenesium>*/