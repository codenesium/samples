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
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "Integration")]
	public class EventTeacherIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EventTeacherIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEventTeacherModelMapper mapper = new ApiEventTeacherModelMapper();

			UpdateResponse<ApiEventTeacherResponseModel> updateResponse = await this.Client.EventTeacherUpdateAsync(model.EventId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EventTeacherDeleteAsync(model.EventId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEventTeacherResponseModel response = await this.Client.EventTeacherGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEventTeacherResponseModel> response = await this.Client.EventTeacherAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventTeacherResponseModel> CreateRecord()
		{
			var model = new ApiEventTeacherRequestModel();
			model.SetProperties(1);
			CreateResponse<ApiEventTeacherResponseModel> result = await this.Client.EventTeacherCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EventTeacherDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>e0a1430dbfb8f7cbee8cefd449714477</Hash>
</Codenesium>*/