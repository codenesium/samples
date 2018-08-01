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
	[Trait("Table", "PersonPhone")]
	[Trait("Area", "Integration")]
	public class PersonPhoneIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PersonPhoneIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPersonPhoneModelMapper mapper = new ApiPersonPhoneModelMapper();

			UpdateResponse<ApiPersonPhoneResponseModel> updateResponse = await this.Client.PersonPhoneUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PersonPhoneDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPersonPhoneResponseModel response = await this.Client.PersonPhoneGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPersonPhoneResponseModel> response = await this.Client.PersonPhoneAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPersonPhoneResponseModel> CreateRecord()
		{
			var model = new ApiPersonPhoneRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2);
			CreateResponse<ApiPersonPhoneResponseModel> result = await this.Client.PersonPhoneCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PersonPhoneDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>6dfab59322bc054623c743ee308108dd</Hash>
</Codenesium>*/