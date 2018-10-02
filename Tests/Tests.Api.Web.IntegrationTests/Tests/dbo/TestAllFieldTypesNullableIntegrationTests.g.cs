using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "Integration")]
	public class TestAllFieldTypesNullableIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TestAllFieldTypesNullableIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTestAllFieldTypesNullableModelMapper mapper = new ApiTestAllFieldTypesNullableModelMapper();

			UpdateResponse<ApiTestAllFieldTypesNullableResponseModel> updateResponse = await this.Client.TestAllFieldTypesNullableUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TestAllFieldTypesNullableDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTestAllFieldTypesNullableResponseModel response = await this.Client.TestAllFieldTypesNullableGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTestAllFieldTypesNullableResponseModel> response = await this.Client.TestAllFieldTypesNullableAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTestAllFieldTypesNullableResponseModel> CreateRecord()
		{
			var model = new ApiTestAllFieldTypesNullableRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("1"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			CreateResponse<ApiTestAllFieldTypesNullableResponseModel> result = await this.Client.TestAllFieldTypesNullableCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TestAllFieldTypesNullableDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>4b5af7a53843982dc49bafb4b6f06105</Hash>
</Codenesium>*/