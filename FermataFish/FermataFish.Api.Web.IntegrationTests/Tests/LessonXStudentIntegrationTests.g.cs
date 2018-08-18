using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "LessonXStudent")]
	[Trait("Area", "Integration")]
	public class LessonXStudentIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LessonXStudentIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLessonXStudentModelMapper mapper = new ApiLessonXStudentModelMapper();

			UpdateResponse<ApiLessonXStudentResponseModel> updateResponse = await this.Client.LessonXStudentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LessonXStudentDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLessonXStudentResponseModel response = await this.Client.LessonXStudentGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLessonXStudentResponseModel> response = await this.Client.LessonXStudentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLessonXStudentResponseModel> CreateRecord()
		{
			var model = new ApiLessonXStudentRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiLessonXStudentResponseModel> result = await this.Client.LessonXStudentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LessonXStudentDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>7cbe443faf5218dbdef3e95b1dc29824</Hash>
</Codenesium>*/