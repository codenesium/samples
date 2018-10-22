using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Machine")]
	[Trait("Area", "Integration")]
	public class MachineIntegrationTests
	{
		public MachineIntegrationTests()
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

			await client.MachineDeleteAsync(1);

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

			ApiMachineResponseModel model = await client.MachineGetAsync(1);

			ApiMachineModelMapper mapper = new ApiMachineModelMapper();

			UpdateResponse<ApiMachineResponseModel> updateResponse = await client.MachineUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiMachineRequestModel();
			createModel.SetProperties("B", "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiMachineResponseModel> createResult = await client.MachineCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiMachineResponseModel getResponse = await client.MachineGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.MachineDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiMachineResponseModel verifyResponse = await client.MachineGetAsync(2);

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
			ApiMachineResponseModel response = await client.MachineGetAsync(1);

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

			List<ApiMachineResponseModel> response = await client.MachineAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMachineResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiMachineRequestModel();
			model.SetProperties("B", "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiMachineResponseModel> result = await client.MachineCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>f6bb127107e1571b33dc2a21f2ad1bc7</Hash>
</Codenesium>*/