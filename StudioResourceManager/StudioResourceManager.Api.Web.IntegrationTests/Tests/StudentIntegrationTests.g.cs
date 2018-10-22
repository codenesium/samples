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
	[Trait("Table", "Student")]
	[Trait("Area", "Integration")]
	public class StudentIntegrationTests
	{
		public StudentIntegrationTests()
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

			await client.StudentDeleteAsync(1);

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

			ApiStudentResponseModel model = await client.StudentGetAsync(1);

			ApiStudentModelMapper mapper = new ApiStudentModelMapper();

			UpdateResponse<ApiStudentResponseModel> updateResponse = await client.StudentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiStudentRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, 1, "B", true, "B", "B", true, 1);
			CreateResponse<ApiStudentResponseModel> createResult = await client.StudentCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiStudentResponseModel getResponse = await client.StudentGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.StudentDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiStudentResponseModel verifyResponse = await client.StudentGetAsync(2);

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
			ApiStudentResponseModel response = await client.StudentGetAsync(1);

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

			List<ApiStudentResponseModel> response = await client.StudentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStudentResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiStudentRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, 1, "B", true, "B", "B", true, 1);
			CreateResponse<ApiStudentResponseModel> result = await client.StudentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c3bfc513d9a91f5a5a8900b73994505c</Hash>
</Codenesium>*/