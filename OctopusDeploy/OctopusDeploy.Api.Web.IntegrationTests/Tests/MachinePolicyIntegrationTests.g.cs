using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "MachinePolicy")]
	[Trait("Area", "Integration")]
	public class MachinePolicyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public MachinePolicyIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestCreate()
		{
			var response = await this.CreateRecord();

			response.Should().NotBeNull();

			await this.Cleanup();
		}

		[Fact]
		public async void TestUpdate()
		{
			var model = await this.CreateRecord();

			ApiMachinePolicyModelMapper mapper = new ApiMachinePolicyModelMapper();

			UpdateResponse<ApiMachinePolicyResponseModel> updateResponse = await this.Client.MachinePolicyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.MachinePolicyDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiMachinePolicyResponseModel response = await this.Client.MachinePolicyGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiMachinePolicyResponseModel> response = await this.Client.MachinePolicyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMachinePolicyResponseModel> CreateRecord()
		{
			var model = new ApiMachinePolicyRequestModel();
			model.SetProperties(true, "B", "B");
			CreateResponse<ApiMachinePolicyResponseModel> result = await this.Client.MachinePolicyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.MachinePolicyDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>75b8f5e3d952651cdc12f1e716cbc4e7</Hash>
</Codenesium>*/