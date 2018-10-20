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

			ApiTeacherSkillResponseModel response = await client.TeacherSkillGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.TeacherSkillDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.TeacherSkillGetAsync(1);

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
			model.SetProperties("B", true);
			CreateResponse<ApiTeacherSkillResponseModel> result = await client.TeacherSkillCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>4f1798a8b327e81d74dc2e1a43a30c67</Hash>
</Codenesium>*/