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
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "Integration")]
	public class ErrorLogIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ErrorLogIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiErrorLogModelMapper mapper = new ApiErrorLogModelMapper();

			UpdateResponse<ApiErrorLogResponseModel> updateResponse = await this.Client.ErrorLogUpdateAsync(model.ErrorLogID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ErrorLogDeleteAsync(model.ErrorLogID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiErrorLogResponseModel response = await this.Client.ErrorLogGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiErrorLogResponseModel> response = await this.Client.ErrorLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiErrorLogResponseModel> CreateRecord()
		{
			var model = new ApiErrorLogRequestModel();
			model.SetProperties(2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiErrorLogResponseModel> result = await this.Client.ErrorLogCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ErrorLogDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>8c711714061303fce9bc458d5e62cac9</Hash>
</Codenesium>*/