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
	[Trait("Table", "Sysdiagram")]
	[Trait("Area", "Integration")]
	public class SysdiagramIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SysdiagramIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSysdiagramModelMapper mapper = new ApiSysdiagramModelMapper();

			UpdateResponse<ApiSysdiagramResponseModel> updateResponse = await this.Client.SysdiagramUpdateAsync(model.DiagramId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SysdiagramDeleteAsync(model.DiagramId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSysdiagramResponseModel response = await this.Client.SysdiagramGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSysdiagramResponseModel> response = await this.Client.SysdiagramAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSysdiagramResponseModel> CreateRecord()
		{
			var model = new ApiSysdiagramRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", 2, 2);
			CreateResponse<ApiSysdiagramResponseModel> result = await this.Client.SysdiagramCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SysdiagramDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>19a360937f1f9b309ba22bf8d4c171dc</Hash>
</Codenesium>*/