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
	[Trait("Table", "Mutex")]
	[Trait("Area", "Integration")]
	public class MutexIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public MutexIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiMutexModelMapper mapper = new ApiMutexModelMapper();

			UpdateResponse<ApiMutexResponseModel> updateResponse = await this.Client.MutexUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.MutexDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiMutexResponseModel response = await this.Client.MutexGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiMutexResponseModel> response = await this.Client.MutexAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMutexResponseModel> CreateRecord()
		{
			var model = new ApiMutexRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiMutexResponseModel> result = await this.Client.MutexCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.MutexDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>acfd9c72baf547fcdb562c9f397c69dd</Hash>
</Codenesium>*/