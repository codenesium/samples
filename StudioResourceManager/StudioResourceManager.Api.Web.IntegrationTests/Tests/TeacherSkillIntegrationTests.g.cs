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
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "Integration")]
	public class TeacherSkillIntegrationTests
	{
		public TeacherSkillIntegrationTests()
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

			await client.TeacherSkillDeleteAsync(1);

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

			ApiTeacherSkillResponseModel model = await client.TeacherSkillGetAsync(1);

			ApiTeacherSkillModelMapper mapper = new ApiTeacherSkillModelMapper();

			UpdateResponse<ApiTeacherSkillResponseModel> updateResponse = await client.TeacherSkillUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTeacherSkillRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiTeacherSkillResponseModel> createResult = await client.TeacherSkillCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTeacherSkillResponseModel getResponse = await client.TeacherSkillGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TeacherSkillDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTeacherSkillResponseModel verifyResponse = await client.TeacherSkillGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiTeacherSkillResponseModel response = await client.TeacherSkillGetAsync(1);

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

			List<ApiTeacherSkillResponseModel> response = await client.TeacherSkillAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeacherSkillResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTeacherSkillRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTeacherSkillResponseModel> result = await client.TeacherSkillCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>4c80ec85a497ff478ed1d4f566cd61e1</Hash>
</Codenesium>*/