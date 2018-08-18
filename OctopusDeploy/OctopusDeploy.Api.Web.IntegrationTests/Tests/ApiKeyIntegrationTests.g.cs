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
	[Trait("Table", "ApiKey")]
	[Trait("Area", "Integration")]
	public class ApiKeyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ApiKeyIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiApiKeyModelMapper mapper = new ApiApiKeyModelMapper();

			UpdateResponse<ApiApiKeyResponseModel> updateResponse = await this.Client.ApiKeyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ApiKeyDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiApiKeyResponseModel response = await this.Client.ApiKeyGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiApiKeyResponseModel> response = await this.Client.ApiKeyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiApiKeyResponseModel> CreateRecord()
		{
			var model = new ApiApiKeyRequestModel();
			model.SetProperties("B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			CreateResponse<ApiApiKeyResponseModel> result = await this.Client.ApiKeyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ApiKeyDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>b8fd256876560dd06490323f90ab17b1</Hash>
</Codenesium>*/