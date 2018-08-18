using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Studio")]
	[Trait("Area", "Integration")]
	public class StudioIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public StudioIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiStudioModelMapper mapper = new ApiStudioModelMapper();

			UpdateResponse<ApiStudioResponseModel> updateResponse = await this.Client.StudioUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.StudioDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiStudioResponseModel response = await this.Client.StudioGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiStudioResponseModel> response = await this.Client.StudioAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStudioResponseModel> CreateRecord()
		{
			var model = new ApiStudioRequestModel();
			model.SetProperties("B", "B", "B", "B", 1, "B", "B");
			CreateResponse<ApiStudioResponseModel> result = await this.Client.StudioCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.StudioDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>4bfee38a7950e691451bca714e42baf4</Hash>
</Codenesium>*/