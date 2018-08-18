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
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "Integration")]
	public class ClientCommunicationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ClientCommunicationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiClientCommunicationModelMapper mapper = new ApiClientCommunicationModelMapper();

			UpdateResponse<ApiClientCommunicationResponseModel> updateResponse = await this.Client.ClientCommunicationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ClientCommunicationDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiClientCommunicationResponseModel response = await this.Client.ClientCommunicationGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiClientCommunicationResponseModel> response = await this.Client.ClientCommunicationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiClientCommunicationResponseModel> CreateRecord()
		{
			var model = new ApiClientCommunicationRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiClientCommunicationResponseModel> result = await this.Client.ClientCommunicationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ClientCommunicationDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a32a2edee753dd1e80c7994202829c52</Hash>
</Codenesium>*/