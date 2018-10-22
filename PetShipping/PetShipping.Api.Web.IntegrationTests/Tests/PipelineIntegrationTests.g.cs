using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "Integration")]
	public class PipelineIntegrationTests
	{
		public PipelineIntegrationTests()
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

			await client.PipelineDeleteAsync(1);

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

			ApiPipelineResponseModel model = await client.PipelineGetAsync(1);

			ApiPipelineModelMapper mapper = new ApiPipelineModelMapper();

			UpdateResponse<ApiPipelineResponseModel> updateResponse = await client.PipelineUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPipelineRequestModel();
			createModel.SetProperties(1, 2);
			CreateResponse<ApiPipelineResponseModel> createResult = await client.PipelineCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPipelineResponseModel getResponse = await client.PipelineGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PipelineDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPipelineResponseModel verifyResponse = await client.PipelineGetAsync(2);

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
			ApiPipelineResponseModel response = await client.PipelineGetAsync(1);

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

			List<ApiPipelineResponseModel> response = await client.PipelineAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPipelineRequestModel();
			model.SetProperties(1, 2);
			CreateResponse<ApiPipelineResponseModel> result = await client.PipelineCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>9a9697911e54635ee9f6d02e3654edf6</Hash>
</Codenesium>*/