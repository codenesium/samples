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
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "Integration")]
	public class PhoneNumberTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PhoneNumberTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPhoneNumberTypeModelMapper mapper = new ApiPhoneNumberTypeModelMapper();

			UpdateResponse<ApiPhoneNumberTypeResponseModel> updateResponse = await this.Client.PhoneNumberTypeUpdateAsync(model.PhoneNumberTypeID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PhoneNumberTypeDeleteAsync(model.PhoneNumberTypeID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPhoneNumberTypeResponseModel response = await this.Client.PhoneNumberTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPhoneNumberTypeResponseModel> response = await this.Client.PhoneNumberTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPhoneNumberTypeResponseModel> CreateRecord()
		{
			var model = new ApiPhoneNumberTypeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiPhoneNumberTypeResponseModel> result = await this.Client.PhoneNumberTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PhoneNumberTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>afd0b3f1f65502afc6b41a65a7e20e43</Hash>
</Codenesium>*/