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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiEventClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			var model2 = new ApiEventClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3m, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C");
			var request = new List<ApiEventClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEventClientResponseModel>> result = await client.EventBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Event>().ToList()[1].ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].BillAmount.Should().Be(2m);
			context.Set<Event>().ToList()[1].EventStatusId.Should().Be(2);
			context.Set<Event>().ToList()[1].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].StudentNote.Should().Be("B");
			context.Set<Event>().ToList()[1].TeacherNote.Should().Be("B");

			context.Set<Event>().ToList()[2].ActualEndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].ActualStartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].BillAmount.Should().Be(3m);
			context.Set<Event>().ToList()[2].EventStatusId.Should().Be(3);
			context.Set<Event>().ToList()[2].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].StudentNote.Should().Be("C");
			context.Set<Event>().ToList()[2].TeacherNote.Should().Be("C");
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

			var model = new ApiEventClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			CreateResponse<ApiEventClientResponseModel> result = await client.EventCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Event>().ToList()[1].ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].BillAmount.Should().Be(2m);
			context.Set<Event>().ToList()[1].EventStatusId.Should().Be(2);
			context.Set<Event>().ToList()[1].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].StudentNote.Should().Be("B");
			context.Set<Event>().ToList()[1].TeacherNote.Should().Be("B");

			result.Record.ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.BillAmount.Should().Be(2m);
			result.Record.EventStatusId.Should().Be(2);
			result.Record.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.StudentNote.Should().Be("B");
			result.Record.TeacherNote.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiEventServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IEventService service = testServer.Host.Services.GetService(typeof(IEventService)) as IEventService;
			ApiEventServerResponseModel model = await service.Get(1);

			ApiEventClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");

			UpdateResponse<ApiEventClientResponseModel> updateResponse = await client.EventUpdateAsync(model.Id, request);

			context.Entry(context.Set<Event>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Event>().ToList()[0].ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].BillAmount.Should().Be(2m);
			context.Set<Event>().ToList()[0].EventStatusId.Should().Be(2);
			context.Set<Event>().ToList()[0].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].StudentNote.Should().Be("B");
			context.Set<Event>().ToList()[0].TeacherNote.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.ActualEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ActualStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.BillAmount.Should().Be(2m);
			updateResponse.Record.EventStatusId.Should().Be(2);
			updateResponse.Record.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.StudentNote.Should().Be("B");
			updateResponse.Record.TeacherNote.Should().Be("B");
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

			IEventService service = testServer.Host.Services.GetService(typeof(IEventService)) as IEventService;
			var model = new ApiEventServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
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
			response.StudentNote.Should().Be("A");
			response.TeacherNote.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
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

			List<ApiEventClientResponseModel> response = await client.EventAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].BillAmount.Should().Be(1m);
			response[0].EventStatusId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].StudentNote.Should().Be("A");
			response[0].TeacherNote.Should().Be("A");
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
    <Hash>f22a9efd70b9bac0128592def892ffe6</Hash>
</Codenesium>*/