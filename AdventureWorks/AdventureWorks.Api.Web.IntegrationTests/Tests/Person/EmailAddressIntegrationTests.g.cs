using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "EmailAddress")]
	[Trait("Area", "Integration")]
	public class EmailAddressIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EmailAddressIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEmailAddressModelMapper mapper = new ApiEmailAddressModelMapper();

			UpdateResponse<ApiEmailAddressResponseModel> updateResponse = await this.Client.EmailAddressUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EmailAddressDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEmailAddressResponseModel response = await this.Client.EmailAddressGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEmailAddressResponseModel> response = await this.Client.EmailAddressAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEmailAddressResponseModel> CreateRecord()
		{
			var model = new ApiEmailAddressRequestModel();
			model.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiEmailAddressResponseModel> result = await this.Client.EmailAddressCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EmailAddressDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>67013f0e9b43696264b989126ff2cdaf</Hash>
</Codenesium>*/