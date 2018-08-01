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
	[Trait("Table", "Interruption")]
	[Trait("Area", "Integration")]
	public class InterruptionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public InterruptionIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiInterruptionModelMapper mapper = new ApiInterruptionModelMapper();

			UpdateResponse<ApiInterruptionResponseModel> updateResponse = await this.Client.InterruptionUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.InterruptionDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiInterruptionResponseModel response = await this.Client.InterruptionGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiInterruptionResponseModel> response = await this.Client.InterruptionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiInterruptionResponseModel> CreateRecord()
		{
			var model = new ApiInterruptionRequestModel();
			model.SetProperties(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiInterruptionResponseModel> result = await this.Client.InterruptionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.InterruptionDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>0b0a5bc6d284ea607a0c560bdf3b2a04</Hash>
</Codenesium>*/