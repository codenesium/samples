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
	[Trait("Table", "Teacher")]
	[Trait("Area", "Integration")]
	public class TeacherIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TeacherIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTeacherModelMapper mapper = new ApiTeacherModelMapper();

			UpdateResponse<ApiTeacherResponseModel> updateResponse = await this.Client.TeacherUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TeacherDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTeacherResponseModel response = await this.Client.TeacherGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTeacherResponseModel> response = await this.Client.TeacherAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeacherResponseModel> CreateRecord()
		{
			var model = new ApiTeacherRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			CreateResponse<ApiTeacherResponseModel> result = await this.Client.TeacherCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TeacherDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>55e7985020a86cd776b60f64ddfc0cc3</Hash>
</Codenesium>*/