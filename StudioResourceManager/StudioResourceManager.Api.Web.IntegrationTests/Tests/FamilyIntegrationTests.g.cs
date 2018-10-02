using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Family")]
	[Trait("Area", "Integration")]
	public class FamilyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public FamilyIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiFamilyModelMapper mapper = new ApiFamilyModelMapper();

			UpdateResponse<ApiFamilyResponseModel> updateResponse = await this.Client.FamilyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.FamilyDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiFamilyResponseModel response = await this.Client.FamilyGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiFamilyResponseModel> response = await this.Client.FamilyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFamilyResponseModel> CreateRecord()
		{
			var model = new ApiFamilyRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiFamilyResponseModel> result = await this.Client.FamilyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.FamilyDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>2bcce3dc2776bca303c3fc7bf30876e1</Hash>
</Codenesium>*/