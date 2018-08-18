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
	[Trait("Table", "Illustration")]
	[Trait("Area", "Integration")]
	public class IllustrationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public IllustrationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiIllustrationModelMapper mapper = new ApiIllustrationModelMapper();

			UpdateResponse<ApiIllustrationResponseModel> updateResponse = await this.Client.IllustrationUpdateAsync(model.IllustrationID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.IllustrationDeleteAsync(model.IllustrationID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiIllustrationResponseModel response = await this.Client.IllustrationGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiIllustrationResponseModel> response = await this.Client.IllustrationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiIllustrationResponseModel> CreateRecord()
		{
			var model = new ApiIllustrationRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiIllustrationResponseModel> result = await this.Client.IllustrationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.IllustrationDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>3443d322d93b211140a7c17d6ccfb8c6</Hash>
</Codenesium>*/