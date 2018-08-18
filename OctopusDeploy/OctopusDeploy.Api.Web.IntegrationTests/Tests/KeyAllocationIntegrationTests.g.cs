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
	[Trait("Table", "KeyAllocation")]
	[Trait("Area", "Integration")]
	public class KeyAllocationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public KeyAllocationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiKeyAllocationModelMapper mapper = new ApiKeyAllocationModelMapper();

			UpdateResponse<ApiKeyAllocationResponseModel> updateResponse = await this.Client.KeyAllocationUpdateAsync(model.CollectionName, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.KeyAllocationDeleteAsync(model.CollectionName);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiKeyAllocationResponseModel response = await this.Client.KeyAllocationGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiKeyAllocationResponseModel> response = await this.Client.KeyAllocationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiKeyAllocationResponseModel> CreateRecord()
		{
			var model = new ApiKeyAllocationRequestModel();
			model.SetProperties(2);
			CreateResponse<ApiKeyAllocationResponseModel> result = await this.Client.KeyAllocationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.KeyAllocationDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>7b08cfe8425fced25eaa4b7d37ba8b27</Hash>
</Codenesium>*/