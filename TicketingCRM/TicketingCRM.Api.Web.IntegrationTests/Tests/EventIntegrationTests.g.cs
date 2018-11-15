using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
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
			model.SetProperties("B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiEventClientRequestModel();
			model2.SetProperties("C", "C", 1, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiEventClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEventClientResponseModel>> result = await client.EventBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Event>().ToList()[1].Address1.Should().Be("B");
			context.Set<Event>().ToList()[1].Address2.Should().Be("B");
			context.Set<Event>().ToList()[1].CityId.Should().Be(1);
			context.Set<Event>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].Description.Should().Be("B");
			context.Set<Event>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].Facebook.Should().Be("B");
			context.Set<Event>().ToList()[1].Name.Should().Be("B");
			context.Set<Event>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].Website.Should().Be("B");

			context.Set<Event>().ToList()[2].Address1.Should().Be("C");
			context.Set<Event>().ToList()[2].Address2.Should().Be("C");
			context.Set<Event>().ToList()[2].CityId.Should().Be(1);
			context.Set<Event>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].Description.Should().Be("C");
			context.Set<Event>().ToList()[2].EndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].Facebook.Should().Be("C");
			context.Set<Event>().ToList()[2].Name.Should().Be("C");
			context.Set<Event>().ToList()[2].StartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Event>().ToList()[2].Website.Should().Be("C");
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
			model.SetProperties("B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiEventClientResponseModel> result = await client.EventCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Event>().ToList()[1].Address1.Should().Be("B");
			context.Set<Event>().ToList()[1].Address2.Should().Be("B");
			context.Set<Event>().ToList()[1].CityId.Should().Be(1);
			context.Set<Event>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].Description.Should().Be("B");
			context.Set<Event>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].Facebook.Should().Be("B");
			context.Set<Event>().ToList()[1].Name.Should().Be("B");
			context.Set<Event>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[1].Website.Should().Be("B");

			result.Record.Address1.Should().Be("B");
			result.Record.Address2.Should().Be("B");
			result.Record.CityId.Should().Be(1);
			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Description.Should().Be("B");
			result.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Facebook.Should().Be("B");
			result.Record.Name.Should().Be("B");
			result.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Website.Should().Be("B");
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
			request.SetProperties("B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiEventClientResponseModel> updateResponse = await client.EventUpdateAsync(model.Id, request);

			context.Entry(context.Set<Event>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Event>().ToList()[0].Address1.Should().Be("B");
			context.Set<Event>().ToList()[0].Address2.Should().Be("B");
			context.Set<Event>().ToList()[0].CityId.Should().Be(1);
			context.Set<Event>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].Description.Should().Be("B");
			context.Set<Event>().ToList()[0].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].Facebook.Should().Be("B");
			context.Set<Event>().ToList()[0].Name.Should().Be("B");
			context.Set<Event>().ToList()[0].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Event>().ToList()[0].Website.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Address1.Should().Be("B");
			updateResponse.Record.Address2.Should().Be("B");
			updateResponse.Record.CityId.Should().Be(1);
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Facebook.Should().Be("B");
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Website.Should().Be("B");
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
			model.SetProperties("B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
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
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.CityId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Facebook.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Website.Should().Be("A");
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
			response[0].Address1.Should().Be("A");
			response[0].Address2.Should().Be("A");
			response[0].CityId.Should().Be(1);
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Description.Should().Be("A");
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Facebook.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Website.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByCityIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiEventClientResponseModel> response = await client.ByEventByCityId(1);

			response.Should().NotBeEmpty();
			response[0].Address1.Should().Be("A");
			response[0].Address2.Should().Be("A");
			response[0].CityId.Should().Be(1);
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Description.Should().Be("A");
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Facebook.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Website.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByCityIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiEventClientResponseModel> response = await client.ByEventByCityId(default(int));

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
    <Hash>cbce1b8bdc7d4c6d433fc2cfe980b9ed</Hash>
</Codenesium>*/