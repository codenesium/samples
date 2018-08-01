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
	[Trait("Table", "ContactType")]
	[Trait("Area", "Integration")]
	public class ContactTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ContactTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiContactTypeModelMapper mapper = new ApiContactTypeModelMapper();

			UpdateResponse<ApiContactTypeResponseModel> updateResponse = await this.Client.ContactTypeUpdateAsync(model.ContactTypeID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ContactTypeDeleteAsync(model.ContactTypeID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiContactTypeResponseModel response = await this.Client.ContactTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiContactTypeResponseModel> response = await this.Client.ContactTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiContactTypeResponseModel> CreateRecord()
		{
			var model = new ApiContactTypeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiContactTypeResponseModel> result = await this.Client.ContactTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ContactTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>48f2d8cb44159582738d448d3ff211bf</Hash>
</Codenesium>*/