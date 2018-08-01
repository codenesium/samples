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
	[Trait("Table", "Lifecycle")]
	[Trait("Area", "Integration")]
	public class LifecycleIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LifecycleIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLifecycleModelMapper mapper = new ApiLifecycleModelMapper();

			UpdateResponse<ApiLifecycleResponseModel> updateResponse = await this.Client.LifecycleUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LifecycleDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLifecycleResponseModel response = await this.Client.LifecycleGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLifecycleResponseModel> response = await this.Client.LifecycleAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLifecycleResponseModel> CreateRecord()
		{
			var model = new ApiLifecycleRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", "B");
			CreateResponse<ApiLifecycleResponseModel> result = await this.Client.LifecycleCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LifecycleDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>9b321c458a5abecd28af548baf54fa1d</Hash>
</Codenesium>*/