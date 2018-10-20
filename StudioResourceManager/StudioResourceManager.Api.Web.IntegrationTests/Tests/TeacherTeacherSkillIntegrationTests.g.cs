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
	public class TeacherTeacherSkillIntegrationTests
	{
		public TeacherTeacherSkillIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.TeacherTeacherSkillDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiTeacherTeacherSkillResponseModel model = await client.TeacherTeacherSkillGetAsync(1);

			ApiTeacherTeacherSkillModelMapper mapper = new ApiTeacherTeacherSkillModelMapper();

			UpdateResponse<ApiTeacherTeacherSkillResponseModel> updateResponse = await client.TeacherTeacherSkillUpdateAsync(model.TeacherId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiTeacherTeacherSkillResponseModel response = await client.TeacherTeacherSkillGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.TeacherTeacherSkillDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.TeacherTeacherSkillGetAsync(1);

			response.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiTeacherTeacherSkillResponseModel response = await client.TeacherTeacherSkillGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiTeacherTeacherSkillResponseModel> response = await client.TeacherTeacherSkillAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeacherTeacherSkillResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTeacherTeacherSkillRequestModel();
			model.SetProperties(1, true);
			CreateResponse<ApiTeacherTeacherSkillResponseModel> result = await client.TeacherTeacherSkillCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>78f9eb90b51738cab6f7cb0c67d32151</Hash>
</Codenesium>*/