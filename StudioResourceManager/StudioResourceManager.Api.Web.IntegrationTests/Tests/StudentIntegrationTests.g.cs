using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Student")]
	[Trait("Area", "Integration")]
	public partial class StudentIntegrationTests
	{
		public StudentIntegrationTests()
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

			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiStudentClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, 1, "B", true, "B", "B", true, 1);
			var model2 = new ApiStudentClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), "C", true, 1, "C", true, "C", "C", true, 1);
			var request = new List<ApiStudentClientRequestModel>() {model, model2};
			CreateResponse<List<ApiStudentClientResponseModel>> result = await client.StudentBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Student>().ToList()[1].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Student>().ToList()[1].Email.Should().Be("B");
			context.Set<Student>().ToList()[1].EmailRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[1].FamilyId.Should().Be(1);
			context.Set<Student>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Student>().ToList()[1].IsAdult.Should().Be(true);
			context.Set<Student>().ToList()[1].LastName.Should().Be("B");
			context.Set<Student>().ToList()[1].Phone.Should().Be("B");
			context.Set<Student>().ToList()[1].SmsRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[1].UserId.Should().Be(1);

			context.Set<Student>().ToList()[2].Birthday.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Student>().ToList()[2].Email.Should().Be("C");
			context.Set<Student>().ToList()[2].EmailRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[2].FamilyId.Should().Be(1);
			context.Set<Student>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Student>().ToList()[2].IsAdult.Should().Be(true);
			context.Set<Student>().ToList()[2].LastName.Should().Be("C");
			context.Set<Student>().ToList()[2].Phone.Should().Be("C");
			context.Set<Student>().ToList()[2].SmsRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[2].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiStudentClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, 1, "B", true, "B", "B", true, 1);
			CreateResponse<ApiStudentClientResponseModel> result = await client.StudentCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Student>().ToList()[1].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Student>().ToList()[1].Email.Should().Be("B");
			context.Set<Student>().ToList()[1].EmailRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[1].FamilyId.Should().Be(1);
			context.Set<Student>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Student>().ToList()[1].IsAdult.Should().Be(true);
			context.Set<Student>().ToList()[1].LastName.Should().Be("B");
			context.Set<Student>().ToList()[1].Phone.Should().Be("B");
			context.Set<Student>().ToList()[1].SmsRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[1].UserId.Should().Be(1);

			result.Record.Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Email.Should().Be("B");
			result.Record.EmailRemindersEnabled.Should().Be(true);
			result.Record.FamilyId.Should().Be(1);
			result.Record.FirstName.Should().Be("B");
			result.Record.IsAdult.Should().Be(true);
			result.Record.LastName.Should().Be("B");
			result.Record.Phone.Should().Be("B");
			result.Record.SmsRemindersEnabled.Should().Be(true);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiStudentServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IStudentService service = testServer.Host.Services.GetService(typeof(IStudentService)) as IStudentService;
			ApiStudentServerResponseModel model = await service.Get(1);

			ApiStudentClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, 1, "B", true, "B", "B", true, 1);

			UpdateResponse<ApiStudentClientResponseModel> updateResponse = await client.StudentUpdateAsync(model.Id, request);

			context.Entry(context.Set<Student>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Student>().ToList()[0].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Student>().ToList()[0].Email.Should().Be("B");
			context.Set<Student>().ToList()[0].EmailRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[0].FamilyId.Should().Be(1);
			context.Set<Student>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Student>().ToList()[0].IsAdult.Should().Be(true);
			context.Set<Student>().ToList()[0].LastName.Should().Be("B");
			context.Set<Student>().ToList()[0].Phone.Should().Be("B");
			context.Set<Student>().ToList()[0].SmsRemindersEnabled.Should().Be(true);
			context.Set<Student>().ToList()[0].UserId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.EmailRemindersEnabled.Should().Be(true);
			updateResponse.Record.FamilyId.Should().Be(1);
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.IsAdult.Should().Be(true);
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.Phone.Should().Be("B");
			updateResponse.Record.SmsRemindersEnabled.Should().Be(true);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IStudentService service = testServer.Host.Services.GetService(typeof(IStudentService)) as IStudentService;
			var model = new ApiStudentServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, 1, "B", true, "B", "B", true, 1);
			CreateResponse<ApiStudentServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.StudentDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiStudentServerResponseModel verifyResponse = await service.Get(2);

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiStudentClientResponseModel response = await client.StudentGetAsync(1);

			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.EmailRemindersEnabled.Should().Be(true);
			response.FamilyId.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.IsAdult.Should().Be(true);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.SmsRemindersEnabled.Should().Be(true);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiStudentClientResponseModel response = await client.StudentGetAsync(default(int));

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiStudentClientResponseModel> response = await client.StudentAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Email.Should().Be("A");
			response[0].EmailRemindersEnabled.Should().Be(true);
			response[0].FamilyId.Should().Be(1);
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].IsAdult.Should().Be(true);
			response[0].LastName.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].SmsRemindersEnabled.Should().Be(true);
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByFamilyIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiStudentClientResponseModel> response = await client.ByStudentByFamilyId(1);

			response.Should().NotBeEmpty();
			response[0].Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Email.Should().Be("A");
			response[0].EmailRemindersEnabled.Should().Be(true);
			response[0].FamilyId.Should().Be(1);
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].IsAdult.Should().Be(true);
			response[0].LastName.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].SmsRemindersEnabled.Should().Be(true);
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByFamilyIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiStudentClientResponseModel> response = await client.ByStudentByFamilyId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiStudentClientResponseModel> response = await client.ByStudentByUserId(1);

			response.Should().NotBeEmpty();
			response[0].Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Email.Should().Be("A");
			response[0].EmailRemindersEnabled.Should().Be(true);
			response[0].FamilyId.Should().Be(1);
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].IsAdult.Should().Be(true);
			response[0].LastName.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].SmsRemindersEnabled.Should().Be(true);
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiStudentClientResponseModel> response = await client.ByStudentByUserId(default(int));

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
				var result = await client.StudentAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>17c616cb2caf4776acd0217a3bfc73a8</Hash>
</Codenesium>*/