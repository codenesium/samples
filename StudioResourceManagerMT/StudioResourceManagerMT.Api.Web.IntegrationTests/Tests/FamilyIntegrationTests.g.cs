using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerMTNS.Api.Client;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Family")]
	[Trait("Area", "Integration")]
	public partial class FamilyIntegrationTests
	{
		public FamilyIntegrationTests()
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

			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiFamilyClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			var model2 = new ApiFamilyClientRequestModel();
			model2.SetProperties("C", "C", "C", "C", "C");
			var request = new List<ApiFamilyClientRequestModel>() {model, model2};
			CreateResponse<List<ApiFamilyClientResponseModel>> result = await client.FamilyBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Family>().ToList()[1].Note.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactEmail.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactFirstName.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactLastName.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactPhone.Should().Be("B");

			context.Set<Family>().ToList()[2].Note.Should().Be("C");
			context.Set<Family>().ToList()[2].PrimaryContactEmail.Should().Be("C");
			context.Set<Family>().ToList()[2].PrimaryContactFirstName.Should().Be("C");
			context.Set<Family>().ToList()[2].PrimaryContactLastName.Should().Be("C");
			context.Set<Family>().ToList()[2].PrimaryContactPhone.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiFamilyClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiFamilyClientResponseModel> result = await client.FamilyCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Family>().ToList()[1].Note.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactEmail.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactFirstName.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactLastName.Should().Be("B");
			context.Set<Family>().ToList()[1].PrimaryContactPhone.Should().Be("B");

			result.Record.Note.Should().Be("B");
			result.Record.PrimaryContactEmail.Should().Be("B");
			result.Record.PrimaryContactFirstName.Should().Be("B");
			result.Record.PrimaryContactLastName.Should().Be("B");
			result.Record.PrimaryContactPhone.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			var mapper = new ApiFamilyServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IFamilyService service = testServer.Host.Services.GetService(typeof(IFamilyService)) as IFamilyService;
			ApiFamilyServerResponseModel model = await service.Get(1);

			ApiFamilyClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", "B", "B");

			UpdateResponse<ApiFamilyClientResponseModel> updateResponse = await client.FamilyUpdateAsync(model.Id, request);

			context.Entry(context.Set<Family>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Family>().ToList()[0].Note.Should().Be("B");
			context.Set<Family>().ToList()[0].PrimaryContactEmail.Should().Be("B");
			context.Set<Family>().ToList()[0].PrimaryContactFirstName.Should().Be("B");
			context.Set<Family>().ToList()[0].PrimaryContactLastName.Should().Be("B");
			context.Set<Family>().ToList()[0].PrimaryContactPhone.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Note.Should().Be("B");
			updateResponse.Record.PrimaryContactEmail.Should().Be("B");
			updateResponse.Record.PrimaryContactFirstName.Should().Be("B");
			updateResponse.Record.PrimaryContactLastName.Should().Be("B");
			updateResponse.Record.PrimaryContactPhone.Should().Be("B");
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IFamilyService service = testServer.Host.Services.GetService(typeof(IFamilyService)) as IFamilyService;
			var model = new ApiFamilyServerRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiFamilyServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.FamilyDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiFamilyServerResponseModel verifyResponse = await service.Get(2);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiFamilyClientResponseModel response = await client.FamilyGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiFamilyClientResponseModel response = await client.FamilyGetAsync(default(int));

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFamilyClientResponseModel> response = await client.FamilyAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Note.Should().Be("A");
			response[0].PrimaryContactEmail.Should().Be("A");
			response[0].PrimaryContactFirstName.Should().Be("A");
			response[0].PrimaryContactLastName.Should().Be("A");
			response[0].PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyStudentsByFamilyIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiStudentClientResponseModel> response = await client.StudentsByFamilyId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyStudentsByFamilyIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiStudentClientResponseModel> response = await client.StudentsByFamilyId(default(int));

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
				var result = await client.FamilyAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>0bbae1da5d1e53730ceb1ace3e311257</Hash>
</Codenesium>*/