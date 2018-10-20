using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "Integration")]
	public class JobCandidateIntegrationTests
	{
		public JobCandidateIntegrationTests()
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

			await client.JobCandidateDeleteAsync(1);

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

			ApiJobCandidateResponseModel model = await client.JobCandidateGetAsync(1);

			ApiJobCandidateModelMapper mapper = new ApiJobCandidateModelMapper();

			UpdateResponse<ApiJobCandidateResponseModel> updateResponse = await client.JobCandidateUpdateAsync(model.JobCandidateID, mapper.MapResponseToRequest(model));

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

			ApiJobCandidateResponseModel response = await client.JobCandidateGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.JobCandidateDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.JobCandidateGetAsync(1);

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
			ApiJobCandidateResponseModel response = await client.JobCandidateGetAsync(1);

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

			List<ApiJobCandidateResponseModel> response = await client.JobCandidateAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiJobCandidateResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiJobCandidateRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiJobCandidateResponseModel> result = await client.JobCandidateCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>6f3de24487c5efdd5f3aa6d34d1eb835</Hash>
</Codenesium>*/