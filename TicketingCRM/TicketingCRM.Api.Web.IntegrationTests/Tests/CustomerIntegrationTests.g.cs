using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Customer")]
	[Trait("Area", "Integration")]
	public class CustomerIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CustomerIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCustomerModelMapper mapper = new ApiCustomerModelMapper();

			UpdateResponse<ApiCustomerResponseModel> updateResponse = await this.Client.CustomerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CustomerDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCustomerResponseModel response = await this.Client.CustomerGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCustomerResponseModel> response = await this.Client.CustomerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCustomerResponseModel> CreateRecord()
		{
			var model = new ApiCustomerRequestModel();
			model.SetProperties("B", "B", "B", "B");
			CreateResponse<ApiCustomerResponseModel> result = await this.Client.CustomerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CustomerDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a11400e027b93736fb902d14b28f8e6c</Hash>
</Codenesium>*/