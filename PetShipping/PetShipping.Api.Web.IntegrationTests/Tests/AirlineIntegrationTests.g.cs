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
	[Trait("Table", "Airline")]
	[Trait("Area", "Integration")]
	public class AirlineIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public AirlineIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiAirlineModelMapper mapper = new ApiAirlineModelMapper();

			UpdateResponse<ApiAirlineResponseModel> updateResponse = await this.Client.AirlineUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.AirlineDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiAirlineResponseModel response = await this.Client.AirlineGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiAirlineResponseModel> response = await this.Client.AirlineAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAirlineResponseModel> CreateRecord()
		{
			var model = new ApiAirlineRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiAirlineResponseModel> result = await this.Client.AirlineCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.AirlineDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>eed211445164e57ca6d751ee9959bc94</Hash>
</Codenesium>*/