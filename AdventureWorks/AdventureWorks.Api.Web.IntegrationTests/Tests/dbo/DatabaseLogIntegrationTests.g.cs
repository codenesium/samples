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
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "Integration")]
	public class DatabaseLogIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public DatabaseLogIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiDatabaseLogModelMapper mapper = new ApiDatabaseLogModelMapper();

			UpdateResponse<ApiDatabaseLogResponseModel> updateResponse = await this.Client.DatabaseLogUpdateAsync(model.DatabaseLogID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.DatabaseLogDeleteAsync(model.DatabaseLogID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiDatabaseLogResponseModel response = await this.Client.DatabaseLogGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiDatabaseLogResponseModel> response = await this.Client.DatabaseLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDatabaseLogResponseModel> CreateRecord()
		{
			var model = new ApiDatabaseLogRequestModel();
			model.SetProperties("B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B");
			CreateResponse<ApiDatabaseLogResponseModel> result = await this.Client.DatabaseLogCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.DatabaseLogDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>f648ccd3901c9c07159f8b4f44178a56</Hash>
</Codenesium>*/