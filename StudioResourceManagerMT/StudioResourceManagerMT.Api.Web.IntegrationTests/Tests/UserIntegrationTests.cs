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
	[Trait("Table", "User")]
	[Trait("Area", "Integration")]
	public partial class UserIntegrationTests
	{
		public UserIntegrationTests()
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

			var model = new ApiUserClientRequestModel();
			model.SetProperties("B", "B");
			var model2 = new ApiUserClientRequestModel();
			model2.SetProperties("C", "C");
			var request = new List<ApiUserClientRequestModel>() {model, model2};
			CreateResponse<List<ApiUserClientResponseModel>> result = await client.UserBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<User>().ToList()[1].Password.Should().Be("B");
			context.Set<User>().ToList()[1].Username.Should().Be("B");

			context.Set<User>().ToList()[2].Password.Should().Be("C");
			context.Set<User>().ToList()[2].Username.Should().Be("C");
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

			var model = new ApiUserClientRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiUserClientResponseModel> result = await client.UserCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<User>().ToList()[1].Password.Should().Be("B");
			context.Set<User>().ToList()[1].Username.Should().Be("B");

			result.Record.Password.Should().Be("B");
			result.Record.Username.Should().Be("B");
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
			var mapper = new ApiUserServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IUserService service = testServer.Host.Services.GetService(typeof(IUserService)) as IUserService;
			ApiUserServerResponseModel model = await service.Get(1);

			ApiUserClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B");

			UpdateResponse<ApiUserClientResponseModel> updateResponse = await client.UserUpdateAsync(model.Id, request);

			context.Entry(context.Set<User>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<User>().ToList()[0].Password.Should().Be("B");
			context.Set<User>().ToList()[0].Username.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Password.Should().Be("B");
			updateResponse.Record.Username.Should().Be("B");
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

			IUserService service = testServer.Host.Services.GetService(typeof(IUserService)) as IUserService;
			var model = new ApiUserServerRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiUserServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.UserDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiUserServerResponseModel verifyResponse = await service.Get(2);

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

			ApiUserClientResponseModel response = await client.UserGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
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
			ApiUserClientResponseModel response = await client.UserGetAsync(default(int));

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
			List<ApiUserClientResponseModel> response = await client.UserAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Password.Should().Be("A");
			response[0].Username.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyAdminsByUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiAdminClientResponseModel> response = await client.AdminsByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyAdminsByUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiAdminClientResponseModel> response = await client.AdminsByUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyStudentsByUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiStudentClientResponseModel> response = await client.StudentsByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyStudentsByUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiStudentClientResponseModel> response = await client.StudentsByUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTeachersByUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTeacherClientResponseModel> response = await client.TeachersByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTeachersByUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTeacherClientResponseModel> response = await client.TeachersByUserId(default(int));

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
				var result = await client.UserAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>870b094fa66ac4b10dcbf8386615695e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/