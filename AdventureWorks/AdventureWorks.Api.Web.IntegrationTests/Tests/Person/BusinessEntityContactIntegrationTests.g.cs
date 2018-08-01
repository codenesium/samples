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
	[Trait("Table", "BusinessEntityContact")]
	[Trait("Area", "Integration")]
	public class BusinessEntityContactIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public BusinessEntityContactIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiBusinessEntityContactModelMapper mapper = new ApiBusinessEntityContactModelMapper();

			UpdateResponse<ApiBusinessEntityContactResponseModel> updateResponse = await this.Client.BusinessEntityContactUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.BusinessEntityContactDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiBusinessEntityContactResponseModel response = await this.Client.BusinessEntityContactGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiBusinessEntityContactResponseModel> response = await this.Client.BusinessEntityContactAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBusinessEntityContactResponseModel> CreateRecord()
		{
			var model = new ApiBusinessEntityContactRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiBusinessEntityContactResponseModel> result = await this.Client.BusinessEntityContactCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.BusinessEntityContactDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>d9ec53c8efe1c42f7991d53ad25279bc</Hash>
</Codenesium>*/