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
	[Trait("Table", "TeacherXTeacherSkill")]
	[Trait("Area", "Integration")]
	public class TeacherXTeacherSkillIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TeacherXTeacherSkillIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTeacherXTeacherSkillModelMapper mapper = new ApiTeacherXTeacherSkillModelMapper();

			UpdateResponse<ApiTeacherXTeacherSkillResponseModel> updateResponse = await this.Client.TeacherXTeacherSkillUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TeacherXTeacherSkillDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTeacherXTeacherSkillResponseModel response = await this.Client.TeacherXTeacherSkillGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTeacherXTeacherSkillResponseModel> response = await this.Client.TeacherXTeacherSkillAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeacherXTeacherSkillResponseModel> CreateRecord()
		{
			var model = new ApiTeacherXTeacherSkillRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiTeacherXTeacherSkillResponseModel> result = await this.Client.TeacherXTeacherSkillCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TeacherXTeacherSkillDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>10178538efaec472597f37bbe73bfabb</Hash>
</Codenesium>*/