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
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Integration")]
	public class ColumnSameAsFKTableIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ColumnSameAsFKTableIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiColumnSameAsFKTableModelMapper mapper = new ApiColumnSameAsFKTableModelMapper();

			UpdateResponse<ApiColumnSameAsFKTableResponseModel> updateResponse = await this.Client.ColumnSameAsFKTableUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ColumnSameAsFKTableDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiColumnSameAsFKTableResponseModel response = await this.Client.ColumnSameAsFKTableGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiColumnSameAsFKTableResponseModel> response = await this.Client.ColumnSameAsFKTableAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiColumnSameAsFKTableResponseModel> CreateRecord()
		{
			var model = new ApiColumnSameAsFKTableRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiColumnSameAsFKTableResponseModel> result = await this.Client.ColumnSameAsFKTableCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ColumnSameAsFKTableDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>91634229bcd91237b91727b83666dce0</Hash>
</Codenesium>*/