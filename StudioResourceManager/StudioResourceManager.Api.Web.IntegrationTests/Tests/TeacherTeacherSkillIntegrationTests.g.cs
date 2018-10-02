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
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "Integration")]
	public class TeacherTeacherSkillIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TeacherTeacherSkillIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTeacherTeacherSkillModelMapper mapper = new ApiTeacherTeacherSkillModelMapper();

			UpdateResponse<ApiTeacherTeacherSkillResponseModel> updateResponse = await this.Client.TeacherTeacherSkillUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TeacherTeacherSkillDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTeacherTeacherSkillResponseModel response = await this.Client.TeacherTeacherSkillGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTeacherTeacherSkillResponseModel> response = await this.Client.TeacherTeacherSkillAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeacherTeacherSkillResponseModel> CreateRecord()
		{
			var model = new ApiTeacherTeacherSkillRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiTeacherTeacherSkillResponseModel> result = await this.Client.TeacherTeacherSkillCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TeacherTeacherSkillDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>c51f003a3627f4b16dec77712e828f55</Hash>
</Codenesium>*/