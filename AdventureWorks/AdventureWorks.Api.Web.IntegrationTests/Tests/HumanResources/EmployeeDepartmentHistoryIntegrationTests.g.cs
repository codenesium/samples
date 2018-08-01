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
	[Trait("Table", "EmployeeDepartmentHistory")]
	[Trait("Area", "Integration")]
	public class EmployeeDepartmentHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EmployeeDepartmentHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEmployeeDepartmentHistoryModelMapper mapper = new ApiEmployeeDepartmentHistoryModelMapper();

			UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel> updateResponse = await this.Client.EmployeeDepartmentHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EmployeeDepartmentHistoryDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEmployeeDepartmentHistoryResponseModel response = await this.Client.EmployeeDepartmentHistoryGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEmployeeDepartmentHistoryResponseModel> response = await this.Client.EmployeeDepartmentHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEmployeeDepartmentHistoryResponseModel> CreateRecord()
		{
			var model = new ApiEmployeeDepartmentHistoryRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> result = await this.Client.EmployeeDepartmentHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EmployeeDepartmentHistoryDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>db1b6d7bb68e983425cb874f1c573e5f</Hash>
</Codenesium>*/