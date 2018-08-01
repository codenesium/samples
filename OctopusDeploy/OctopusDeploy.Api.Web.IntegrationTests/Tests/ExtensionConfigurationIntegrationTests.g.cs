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
	[Trait("Table", "ExtensionConfiguration")]
	[Trait("Area", "Integration")]
	public class ExtensionConfigurationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ExtensionConfigurationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiExtensionConfigurationModelMapper mapper = new ApiExtensionConfigurationModelMapper();

			UpdateResponse<ApiExtensionConfigurationResponseModel> updateResponse = await this.Client.ExtensionConfigurationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ExtensionConfigurationDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiExtensionConfigurationResponseModel response = await this.Client.ExtensionConfigurationGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiExtensionConfigurationResponseModel> response = await this.Client.ExtensionConfigurationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiExtensionConfigurationResponseModel> CreateRecord()
		{
			var model = new ApiExtensionConfigurationRequestModel();
			model.SetProperties("B", "B", "B");
			CreateResponse<ApiExtensionConfigurationResponseModel> result = await this.Client.ExtensionConfigurationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ExtensionConfigurationDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>be58e7b8679f7c474dcf42aab698da23</Hash>
</Codenesium>*/