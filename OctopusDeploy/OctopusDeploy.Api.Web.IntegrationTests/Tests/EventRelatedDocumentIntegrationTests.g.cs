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
	[Trait("Table", "EventRelatedDocument")]
	[Trait("Area", "Integration")]
	public class EventRelatedDocumentIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EventRelatedDocumentIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEventRelatedDocumentModelMapper mapper = new ApiEventRelatedDocumentModelMapper();

			UpdateResponse<ApiEventRelatedDocumentResponseModel> updateResponse = await this.Client.EventRelatedDocumentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EventRelatedDocumentDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEventRelatedDocumentResponseModel response = await this.Client.EventRelatedDocumentGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEventRelatedDocumentResponseModel> response = await this.Client.EventRelatedDocumentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventRelatedDocumentResponseModel> CreateRecord()
		{
			var model = new ApiEventRelatedDocumentRequestModel();
			model.SetProperties("A", "B");
			CreateResponse<ApiEventRelatedDocumentResponseModel> result = await this.Client.EventRelatedDocumentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EventRelatedDocumentDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>7cebdb5454264c31c21e76b84590da53</Hash>
</Codenesium>*/