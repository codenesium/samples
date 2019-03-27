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
	[Trait("Table", "Event")]
	[Trait("Area", "Integration")]
	public partial class EventIntegrationTests
	{
		public EventIntegrationTests()
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

			var model = new ApiEventClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			var model2 = new ApiEventClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3m, 1, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C");
			var request = new List<ApiEventClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEventClientResponseModel>> result = await client.EventBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Event>().ToList()[1].ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].BillAmount.Should().Be(2m);
			context.Set<Event>().ToList()[1].EventStatusId.Should().Be(1);
			context.Set<Event>().ToList()[1].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].StudentNotes.Should().Be("B");
			context.Set<Event>().ToList()[1].TeacherNotes.Should().Be("B");

			context.Set<Event>().ToList()[2].ActualEndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].ActualStartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].BillAmount.Should().Be(3m);
			context.Set<Event>().ToList()[2].EventStatusId.Should().Be(1);
			context.Set<Event>().ToList()[2].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].StudentNotes.Should().Be("C");
			context.Set<Event>().ToList()[2].TeacherNotes.Should().Be("C");
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

			var model = new ApiEventClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			CreateResponse<ApiEventClientResponseModel> result = await client.EventCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Event>().ToList()[1].ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].BillAmount.Should().Be(2m);
			context.Set<Event>().ToList()[1].EventStatusId.Should().Be(1);
			context.Set<Event>().ToList()[1].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].StudentNotes.Should().Be("B");
			context.Set<Event>().ToList()[1].TeacherNotes.Should().Be("B");

			result.Record.ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.BillAmount.Should().Be(2m);
			result.Record.EventStatusId.Should().Be(1);
			result.Record.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.StudentNotes.Should().Be("B");
			result.Record.TeacherNotes.Should().Be("B");
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
			var mapper = new ApiEventServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IEventService service = testServer.Host.Services.GetService(typeof(IEventService)) as IEventService;
			ApiEventServerResponseModel model = await service.Get(1);

			ApiEventClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");

			UpdateResponse<ApiEventClientResponseModel> updateResponse = await client.EventUpdateAsync(model.Id, request);

			context.Entry(context.Set<Event>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Event>().ToList()[0].ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].BillAmount.Should().Be(2m);
			context.Set<Event>().ToList()[0].EventStatusId.Should().Be(1);
			context.Set<Event>().ToList()[0].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].StudentNotes.Should().Be("B");
			context.Set<Event>().ToList()[0].TeacherNotes.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.BillAmount.Should().Be(2m);
			updateResponse.Record.EventStatusId.Should().Be(1);
			updateResponse.Record.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.StudentNotes.Should().Be("B");
			updateResponse.Record.TeacherNotes.Should().Be("B");
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

			IEventService service = testServer.Host.Services.GetService(typeof(IEventService)) as IEventService;
			var model = new ApiEventServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			CreateResponse<ApiEventServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.EventDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiEventServerResponseModel verifyResponse = await service.Get(2);

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

			ApiEventClientResponseModel response = await client.EventGetAsync(1);

			response.Should().NotBeNull();
			response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BillAmount.Should().Be(1m);
			response.EventStatusId.Should().Be(1);
			response.Id.Should().Be(1);
			response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StudentNotes.Should().Be("A");
			response.TeacherNotes.Should().Be("A");
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
			ApiEventClientResponseModel response = await client.EventGetAsync(default(int));

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
			List<ApiEventClientResponseModel> response = await client.EventAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].BillAmount.Should().Be(1m);
			response[0].EventStatusId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].StudentNotes.Should().Be("A");
			response[0].TeacherNotes.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByEventStatusIdFound()
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
			List<ApiEventClientResponseModel> response = await client.ByEventByEventStatusId(1);

			response.Should().NotBeEmpty();
			response[0].ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].BillAmount.Should().Be(1m);
			response[0].EventStatusId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].StudentNotes.Should().Be("A");
			response[0].TeacherNotes.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByEventStatusIdNotFound()
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
			List<ApiEventClientResponseModel> response = await client.ByEventByEventStatusId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyEventStudentsByEventIdFound()
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
			List<ApiEventStudentClientResponseModel> response = await client.EventStudentsByEventId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyEventStudentsByEventIdNotFound()
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
			List<ApiEventStudentClientResponseModel> response = await client.EventStudentsByEventId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyEventTeachersByIdFound()
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
			List<ApiEventTeacherClientResponseModel> response = await client.EventTeachersById(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyEventTeachersByIdNotFound()
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
			List<ApiEventTeacherClientResponseModel> response = await client.EventTeachersById(default(int));

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
				var result = await client.EventAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>fc219d045ceb6ad6addd4c91cf7c7b98</Hash>
</Codenesium>*/