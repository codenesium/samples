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
	[Trait("Table", "PersonCreditCard")]
	[Trait("Area", "Integration")]
	public class PersonCreditCardIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PersonCreditCardIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPersonCreditCardModelMapper mapper = new ApiPersonCreditCardModelMapper();

			UpdateResponse<ApiPersonCreditCardResponseModel> updateResponse = await this.Client.PersonCreditCardUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PersonCreditCardDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPersonCreditCardResponseModel response = await this.Client.PersonCreditCardGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPersonCreditCardResponseModel> response = await this.Client.PersonCreditCardAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPersonCreditCardResponseModel> CreateRecord()
		{
			var model = new ApiPersonCreditCardRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiPersonCreditCardResponseModel> result = await this.Client.PersonCreditCardCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PersonCreditCardDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>203483032ad51f49ca22e3aecbc2aebe</Hash>
</Codenesium>*/