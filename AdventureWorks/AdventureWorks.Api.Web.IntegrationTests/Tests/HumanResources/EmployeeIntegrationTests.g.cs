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
	[Trait("Table", "Employee")]
	[Trait("Area", "Integration")]
	public class EmployeeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EmployeeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEmployeeModelMapper mapper = new ApiEmployeeModelMapper();

			UpdateResponse<ApiEmployeeResponseModel> updateResponse = await this.Client.EmployeeUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EmployeeDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEmployeeResponseModel response = await this.Client.EmployeeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEmployeeResponseModel> response = await this.Client.EmployeeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEmployeeResponseModel> CreateRecord()
		{
			var model = new ApiEmployeeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), true, 2, 2);
			CreateResponse<ApiEmployeeResponseModel> result = await this.Client.EmployeeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EmployeeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>fb42a398e3382d1dabcbbe40c23625e0</Hash>
</Codenesium>*/