using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Handler")]
	[Trait("Area", "Integration")]
	public class HandlerIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public HandlerIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiHandlerModelMapper mapper = new ApiHandlerModelMapper();

			UpdateResponse<ApiHandlerResponseModel> updateResponse = await this.Client.HandlerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.HandlerDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiHandlerResponseModel response = await this.Client.HandlerGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiHandlerResponseModel> response = await this.Client.HandlerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiHandlerResponseModel> CreateRecord()
		{
			var model = new ApiHandlerRequestModel();
			model.SetProperties(2, "B", "B", "B", "B");
			CreateResponse<ApiHandlerResponseModel> result = await this.Client.HandlerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.HandlerDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>ed1be9da0d50627af442bcee51585fd3</Hash>
</Codenesium>*/