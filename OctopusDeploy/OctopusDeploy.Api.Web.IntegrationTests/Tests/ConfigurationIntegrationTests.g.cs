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
	[Trait("Table", "Configuration")]
	[Trait("Area", "Integration")]
	public class ConfigurationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ConfigurationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiConfigurationModelMapper mapper = new ApiConfigurationModelMapper();

			UpdateResponse<ApiConfigurationResponseModel> updateResponse = await this.Client.ConfigurationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ConfigurationDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiConfigurationResponseModel response = await this.Client.ConfigurationGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiConfigurationResponseModel> response = await this.Client.ConfigurationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiConfigurationResponseModel> CreateRecord()
		{
			var model = new ApiConfigurationRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiConfigurationResponseModel> result = await this.Client.ConfigurationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ConfigurationDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>f1884e12cb2bb2b5f88d179f5452be83</Hash>
</Codenesium>*/