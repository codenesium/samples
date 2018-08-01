using FileServiceNS.Api.Client;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "Integration")]
	public class BucketIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public BucketIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiBucketModelMapper mapper = new ApiBucketModelMapper();

			UpdateResponse<ApiBucketResponseModel> updateResponse = await this.Client.BucketUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.BucketDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiBucketResponseModel response = await this.Client.BucketGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiBucketResponseModel> response = await this.Client.BucketAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBucketResponseModel> CreateRecord()
		{
			var model = new ApiBucketRequestModel();
			model.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiBucketResponseModel> result = await this.Client.BucketCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.BucketDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>9f555bae78e86f4d9c1b8e298957e35f</Hash>
</Codenesium>*/