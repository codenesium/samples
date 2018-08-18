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
	[Trait("Table", "Client")]
	[Trait("Area", "Integration")]
	public class ClientIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ClientIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiClientModelMapper mapper = new ApiClientModelMapper();

			UpdateResponse<ApiClientResponseModel> updateResponse = await this.Client.ClientUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ClientDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiClientResponseModel response = await this.Client.ClientGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiClientResponseModel> response = await this.Client.ClientAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiClientResponseModel> CreateRecord()
		{
			var model = new ApiClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiClientResponseModel> result = await this.Client.ClientCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ClientDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>3510e13c8b9bbfbaf5ab7bf140b51a7f</Hash>
</Codenesium>*/