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
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "Integration")]
	public class TestAllFieldTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TestAllFieldTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTestAllFieldTypeModelMapper mapper = new ApiTestAllFieldTypeModelMapper();

			UpdateResponse<ApiTestAllFieldTypeResponseModel> updateResponse = await this.Client.TestAllFieldTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TestAllFieldTypeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTestAllFieldTypeResponseModel response = await this.Client.TestAllFieldTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTestAllFieldTypeResponseModel> response = await this.Client.TestAllFieldTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTestAllFieldTypeResponseModel> CreateRecord()
		{
			var model = new ApiTestAllFieldTypeRequestModel();
			model.SetProperties(2, BitConverter.GetBytes(2), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2, 2, BitConverter.GetBytes(2), 2m, "B", "B", 2m, "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B", TimeSpan.Parse("1"), BitConverter.GetBytes(2), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), BitConverter.GetBytes(2), "B", "B");
			CreateResponse<ApiTestAllFieldTypeResponseModel> result = await this.Client.TestAllFieldTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TestAllFieldTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>980ee2e795f145e17a9b303b405384f8</Hash>
</Codenesium>*/