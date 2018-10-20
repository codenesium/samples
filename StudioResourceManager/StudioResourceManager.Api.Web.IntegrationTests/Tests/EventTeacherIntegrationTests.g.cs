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
	public class EventTeacherIntegrationTests
	{
		public EventTeacherIntegrationTests()
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

			await client.EventTeacherDeleteAsync(1);

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

			ApiEventTeacherResponseModel model = await client.EventTeacherGetAsync(1);

			ApiEventTeacherModelMapper mapper = new ApiEventTeacherModelMapper();

			UpdateResponse<ApiEventTeacherResponseModel> updateResponse = await client.EventTeacherUpdateAsync(model.EventId, mapper.MapResponseToRequest(model));

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

			ApiEventTeacherResponseModel response = await client.EventTeacherGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.EventTeacherDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.EventTeacherGetAsync(1);

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
			ApiEventTeacherResponseModel response = await client.EventTeacherGetAsync(1);

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

			List<ApiEventTeacherResponseModel> response = await client.EventTeacherAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventTeacherResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEventTeacherRequestModel();
			model.SetProperties(1, true);
			CreateResponse<ApiEventTeacherResponseModel> result = await client.EventTeacherCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>384b3eda6bf46f6e12a30364c72757db</Hash>
</Codenesium>*/