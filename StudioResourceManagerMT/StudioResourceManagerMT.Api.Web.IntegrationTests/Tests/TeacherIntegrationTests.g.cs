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
	[Trait("Table", "Teacher")]
	[Trait("Area", "Integration")]
	public partial class TeacherIntegrationTests
	{
		public TeacherIntegrationTests()
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

			var model = new ApiTeacherClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			var model2 = new ApiTeacherClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C", "C", "C", 1);
			var request = new List<ApiTeacherClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTeacherClientResponseModel>> result = await client.TeacherBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Teacher>().ToList()[1].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Teacher>().ToList()[1].Email.Should().Be("B");
			context.Set<Teacher>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Teacher>().ToList()[1].LastName.Should().Be("B");
			context.Set<Teacher>().ToList()[1].Phone.Should().Be("B");
			context.Set<Teacher>().ToList()[1].UserId.Should().Be(1);

			context.Set<Teacher>().ToList()[2].Birthday.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Teacher>().ToList()[2].Email.Should().Be("C");
			context.Set<Teacher>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Teacher>().ToList()[2].LastName.Should().Be("C");
			context.Set<Teacher>().ToList()[2].Phone.Should().Be("C");
			context.Set<Teacher>().ToList()[2].UserId.Should().Be(1);
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

			var model = new ApiTeacherClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			CreateResponse<ApiTeacherClientResponseModel> result = await client.TeacherCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Teacher>().ToList()[1].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Teacher>().ToList()[1].Email.Should().Be("B");
			context.Set<Teacher>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Teacher>().ToList()[1].LastName.Should().Be("B");
			context.Set<Teacher>().ToList()[1].Phone.Should().Be("B");
			context.Set<Teacher>().ToList()[1].UserId.Should().Be(1);

			result.Record.Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Email.Should().Be("B");
			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.Phone.Should().Be("B");
			result.Record.UserId.Should().Be(1);
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
			var mapper = new ApiTeacherServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITeacherService service = testServer.Host.Services.GetService(typeof(ITeacherService)) as ITeacherService;
			ApiTeacherServerResponseModel model = await service.Get(1);

			ApiTeacherClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);

			UpdateResponse<ApiTeacherClientResponseModel> updateResponse = await client.TeacherUpdateAsync(model.Id, request);

			context.Entry(context.Set<Teacher>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Teacher>().ToList()[0].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Teacher>().ToList()[0].Email.Should().Be("B");
			context.Set<Teacher>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Teacher>().ToList()[0].LastName.Should().Be("B");
			context.Set<Teacher>().ToList()[0].Phone.Should().Be("B");
			context.Set<Teacher>().ToList()[0].UserId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.Phone.Should().Be("B");
			updateResponse.Record.UserId.Should().Be(1);
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

			ITeacherService service = testServer.Host.Services.GetService(typeof(ITeacherService)) as ITeacherService;
			var model = new ApiTeacherServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			CreateResponse<ApiTeacherServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TeacherDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTeacherServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTeacherClientResponseModel response = await client.TeacherGetAsync(1);

			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
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
			ApiTeacherClientResponseModel response = await client.TeacherGetAsync(default(int));

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
			List<ApiTeacherClientResponseModel> response = await client.TeacherAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Email.Should().Be("A");
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastName.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestForeignKeyEventTeachersByTeacherIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventTeacherClientResponseModel> response = await client.EventTeachersByTeacherId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyEventTeachersByTeacherIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiEventTeacherClientResponseModel> response = await client.EventTeachersByTeacherId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRatesByTeacherIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiRateClientResponseModel> response = await client.RatesByTeacherId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRatesByTeacherIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiRateClientResponseModel> response = await client.RatesByTeacherId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTeacherTeacherSkillsByTeacherIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTeacherTeacherSkillClientResponseModel> response = await client.TeacherTeacherSkillsByTeacherId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTeacherTeacherSkillsByTeacherIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTeacherTeacherSkillClientResponseModel> response = await client.TeacherTeacherSkillsByTeacherId(default(int));

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
				var result = await client.TeacherAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>cbc2ccfeedd195f0425eea215cfbbd14</Hash>
</Codenesium>*/