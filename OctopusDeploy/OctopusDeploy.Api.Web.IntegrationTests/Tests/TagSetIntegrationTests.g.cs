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
	[Trait("Table", "TagSet")]
	[Trait("Area", "Integration")]
	public class TagSetIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TagSetIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTagSetModelMapper mapper = new ApiTagSetModelMapper();

			UpdateResponse<ApiTagSetResponseModel> updateResponse = await this.Client.TagSetUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TagSetDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTagSetResponseModel response = await this.Client.TagSetGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTagSetResponseModel> response = await this.Client.TagSetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTagSetResponseModel> CreateRecord()
		{
			var model = new ApiTagSetRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", "B", 2);
			CreateResponse<ApiTagSetResponseModel> result = await this.Client.TagSetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TagSetDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>25bcd032885bbbfa846018364c80cf96</Hash>
</Codenesium>*/