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
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Integration")]
	public class IncludedColumnTestIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public IncludedColumnTestIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiIncludedColumnTestModelMapper mapper = new ApiIncludedColumnTestModelMapper();

			UpdateResponse<ApiIncludedColumnTestResponseModel> updateResponse = await this.Client.IncludedColumnTestUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.IncludedColumnTestDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiIncludedColumnTestResponseModel response = await this.Client.IncludedColumnTestGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiIncludedColumnTestResponseModel> response = await this.Client.IncludedColumnTestAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiIncludedColumnTestResponseModel> CreateRecord()
		{
			var model = new ApiIncludedColumnTestRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiIncludedColumnTestResponseModel> result = await this.Client.IncludedColumnTestCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.IncludedColumnTestDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a2235fcd68ac1eb45f0fb84f05f08117</Hash>
</Codenesium>*/