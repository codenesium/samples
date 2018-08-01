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
	[Trait("Table", "Channel")]
	[Trait("Area", "Integration")]
	public class ChannelIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ChannelIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiChannelModelMapper mapper = new ApiChannelModelMapper();

			UpdateResponse<ApiChannelResponseModel> updateResponse = await this.Client.ChannelUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ChannelDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiChannelResponseModel response = await this.Client.ChannelGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiChannelResponseModel> response = await this.Client.ChannelAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiChannelResponseModel> CreateRecord()
		{
			var model = new ApiChannelRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", "B", "B", "B", "B");
			CreateResponse<ApiChannelResponseModel> result = await this.Client.ChannelCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ChannelDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>6c75e8f5b49203e40155409e6577170a</Hash>
</Codenesium>*/