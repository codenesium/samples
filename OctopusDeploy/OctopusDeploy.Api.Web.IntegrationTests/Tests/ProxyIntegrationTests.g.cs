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
	[Trait("Table", "Proxy")]
	[Trait("Area", "Integration")]
	public class ProxyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProxyIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProxyModelMapper mapper = new ApiProxyModelMapper();

			UpdateResponse<ApiProxyResponseModel> updateResponse = await this.Client.ProxyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProxyDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProxyResponseModel response = await this.Client.ProxyGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProxyResponseModel> response = await this.Client.ProxyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProxyResponseModel> CreateRecord()
		{
			var model = new ApiProxyRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiProxyResponseModel> result = await this.Client.ProxyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProxyDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>767050a5f964e8124ca5205fe12437d4</Hash>
</Codenesium>*/