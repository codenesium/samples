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
	[Trait("Table", "EventStudent")]
	[Trait("Area", "Integration")]
	public class EventStudentIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EventStudentIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEventStudentModelMapper mapper = new ApiEventStudentModelMapper();

			UpdateResponse<ApiEventStudentResponseModel> updateResponse = await this.Client.EventStudentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EventStudentDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEventStudentResponseModel response = await this.Client.EventStudentGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEventStudentResponseModel> response = await this.Client.EventStudentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventStudentResponseModel> CreateRecord()
		{
			var model = new ApiEventStudentRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiEventStudentResponseModel> result = await this.Client.EventStudentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EventStudentDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>a6c4397d6165bf4d1d9f213830233cae</Hash>
</Codenesium>*/