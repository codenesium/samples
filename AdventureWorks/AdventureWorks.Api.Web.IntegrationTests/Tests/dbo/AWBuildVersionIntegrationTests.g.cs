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
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "Integration")]
	public class AWBuildVersionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public AWBuildVersionIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiAWBuildVersionModelMapper mapper = new ApiAWBuildVersionModelMapper();

			UpdateResponse<ApiAWBuildVersionResponseModel> updateResponse = await this.Client.AWBuildVersionUpdateAsync(model.SystemInformationID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.AWBuildVersionDeleteAsync(model.SystemInformationID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiAWBuildVersionResponseModel response = await this.Client.AWBuildVersionGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiAWBuildVersionResponseModel> response = await this.Client.AWBuildVersionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAWBuildVersionResponseModel> CreateRecord()
		{
			var model = new ApiAWBuildVersionRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiAWBuildVersionResponseModel> result = await this.Client.AWBuildVersionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.AWBuildVersionDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>8e13476e0e9c2c6784da5398a23e34a8</Hash>
</Codenesium>*/