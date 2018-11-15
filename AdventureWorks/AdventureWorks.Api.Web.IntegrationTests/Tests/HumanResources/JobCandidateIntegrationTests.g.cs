using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "Integration")]
	public partial class JobCandidateIntegrationTests
	{
		public JobCandidateIntegrationTests()
		{
		}

		[Fact]
		public virtual async void TestBulkInsert()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiJobCandidateClientRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiJobCandidateClientRequestModel();
			model2.SetProperties(3, DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiJobCandidateClientRequestModel>() {model, model2};
			CreateResponse<List<ApiJobCandidateClientResponseModel>> result = await client.JobCandidateBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<JobCandidate>().ToList()[1].BusinessEntityID.Should().Be(2);
			context.Set<JobCandidate>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<JobCandidate>().ToList()[1].Resume.Should().Be("B");

			context.Set<JobCandidate>().ToList()[2].BusinessEntityID.Should().Be(3);
			context.Set<JobCandidate>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<JobCandidate>().ToList()[2].Resume.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiJobCandidateClientRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiJobCandidateClientResponseModel> result = await client.JobCandidateCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<JobCandidate>().ToList()[1].BusinessEntityID.Should().Be(2);
			context.Set<JobCandidate>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<JobCandidate>().ToList()[1].Resume.Should().Be("B");

			result.Record.BusinessEntityID.Should().Be(2);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Resume.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiJobCandidateServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IJobCandidateService service = testServer.Host.Services.GetService(typeof(IJobCandidateService)) as IJobCandidateService;
			ApiJobCandidateServerResponseModel model = await service.Get(1);

			ApiJobCandidateClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiJobCandidateClientResponseModel> updateResponse = await client.JobCandidateUpdateAsync(model.JobCandidateID, request);

			context.Entry(context.Set<JobCandidate>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.JobCandidateID.Should().Be(1);
			context.Set<JobCandidate>().ToList()[0].BusinessEntityID.Should().Be(2);
			context.Set<JobCandidate>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<JobCandidate>().ToList()[0].Resume.Should().Be("B");

			updateResponse.Record.JobCandidateID.Should().Be(1);
			updateResponse.Record.BusinessEntityID.Should().Be(2);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Resume.Should().Be("B");
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IJobCandidateService service = testServer.Host.Services.GetService(typeof(IJobCandidateService)) as IJobCandidateService;
			var model = new ApiJobCandidateServerRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiJobCandidateServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.JobCandidateDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiJobCandidateServerResponseModel verifyResponse = await service.Get(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public virtual async void TestGetFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiJobCandidateClientResponseModel response = await client.JobCandidateGetAsync(1);

			response.Should().NotBeNull();
			response.BusinessEntityID.Should().Be(1);
			response.JobCandidateID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Resume.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiJobCandidateClientResponseModel response = await client.JobCandidateGetAsync(default(int));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiJobCandidateClientResponseModel> response = await client.JobCandidateAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].BusinessEntityID.Should().Be(1);
			response[0].JobCandidateID.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Resume.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByBusinessEntityIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiJobCandidateClientResponseModel> response = await client.ByJobCandidateByBusinessEntityID(1);

			response.Should().NotBeEmpty();
			response[0].BusinessEntityID.Should().Be(1);
			response[0].JobCandidateID.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Resume.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByBusinessEntityIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiJobCandidateClientResponseModel> response = await client.ByJobCandidateByBusinessEntityID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual void TestClientCancellationToken()
		{
			Func<Task> testCancellation = async () =>
			{
				var builder = new WebHostBuilder()
				              .UseEnvironment("Production")
				              .UseStartup<TestStartup>();
				TestServer testServer = new TestServer(builder);

				var client = new ApiClient(testServer.BaseAddress.OriginalString);
				CancellationTokenSource tokenSource = new CancellationTokenSource();
				CancellationToken token = tokenSource.Token;
				tokenSource.Cancel();
				var result = await client.JobCandidateAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>1992c44db18f3debd09ad2b763ea9e39</Hash>
</Codenesium>*/