using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Feed")]
	[Trait("Area", "Integration")]
	public class FeedIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public FeedIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiFeedModelMapper mapper = new ApiFeedModelMapper();

			UpdateResponse<ApiFeedResponseModel> updateResponse = await this.Client.FeedUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.FeedDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiFeedResponseModel response = await this.Client.FeedGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiFeedResponseModel> response = await this.Client.FeedAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFeedResponseModel> CreateRecord()
		{
			var model = new ApiFeedRequestModel();
			model.SetProperties("B", "B", "B", "B");
			CreateResponse<ApiFeedResponseModel> result = await this.Client.FeedCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.FeedDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>9a68c7b033104606969f4a056946c4e7</Hash>
</Codenesium>*/