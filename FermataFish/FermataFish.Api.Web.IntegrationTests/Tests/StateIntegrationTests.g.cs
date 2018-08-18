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
	[Trait("Table", "State")]
	[Trait("Area", "Integration")]
	public class StateIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public StateIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiStateModelMapper mapper = new ApiStateModelMapper();

			UpdateResponse<ApiStateResponseModel> updateResponse = await this.Client.StateUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.StateDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiStateResponseModel response = await this.Client.StateGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiStateResponseModel> response = await this.Client.StateAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStateResponseModel> CreateRecord()
		{
			var model = new ApiStateRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiStateResponseModel> result = await this.Client.StateCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.StateDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>6b1e69e6de7af42775655d6cf14abece</Hash>
</Codenesium>*/