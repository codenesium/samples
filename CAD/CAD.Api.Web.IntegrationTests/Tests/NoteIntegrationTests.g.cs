using CADNS.Api.Client;
using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Note")]
	[Trait("Area", "Integration")]
	public partial class NoteIntegrationTests
	{
		public NoteIntegrationTests()
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

			var model = new ApiNoteClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			var model2 = new ApiNoteClientRequestModel();
			model2.SetProperties(1, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", 1);
			var request = new List<ApiNoteClientRequestModel>() {model, model2};
			CreateResponse<List<ApiNoteClientResponseModel>> result = await client.NoteBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Note>().ToList()[1].CallId.Should().Be(1);
			context.Set<Note>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Note>().ToList()[1].NoteText.Should().Be("B");
			context.Set<Note>().ToList()[1].OfficerId.Should().Be(1);

			context.Set<Note>().ToList()[2].CallId.Should().Be(1);
			context.Set<Note>().ToList()[2].DateCreated.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Note>().ToList()[2].NoteText.Should().Be("C");
			context.Set<Note>().ToList()[2].OfficerId.Should().Be(1);
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

			var model = new ApiNoteClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			CreateResponse<ApiNoteClientResponseModel> result = await client.NoteCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Note>().ToList()[1].CallId.Should().Be(1);
			context.Set<Note>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Note>().ToList()[1].NoteText.Should().Be("B");
			context.Set<Note>().ToList()[1].OfficerId.Should().Be(1);

			result.Record.CallId.Should().Be(1);
			result.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.NoteText.Should().Be("B");
			result.Record.OfficerId.Should().Be(1);
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
			var mapper = new ApiNoteServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			INoteService service = testServer.Host.Services.GetService(typeof(INoteService)) as INoteService;
			ApiNoteServerResponseModel model = await service.Get(1);

			ApiNoteClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);

			UpdateResponse<ApiNoteClientResponseModel> updateResponse = await client.NoteUpdateAsync(model.Id, request);

			context.Entry(context.Set<Note>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Note>().ToList()[0].CallId.Should().Be(1);
			context.Set<Note>().ToList()[0].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Note>().ToList()[0].NoteText.Should().Be("B");
			context.Set<Note>().ToList()[0].OfficerId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CallId.Should().Be(1);
			updateResponse.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.NoteText.Should().Be("B");
			updateResponse.Record.OfficerId.Should().Be(1);
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

			INoteService service = testServer.Host.Services.GetService(typeof(INoteService)) as INoteService;
			var model = new ApiNoteServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1);
			CreateResponse<ApiNoteServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.NoteDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiNoteServerResponseModel verifyResponse = await service.Get(2);

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

			ApiNoteClientResponseModel response = await client.NoteGetAsync(1);

			response.Should().NotBeNull();
			response.CallId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.NoteText.Should().Be("A");
			response.OfficerId.Should().Be(1);
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
			ApiNoteClientResponseModel response = await client.NoteGetAsync(default(int));

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
			List<ApiNoteClientResponseModel> response = await client.NoteAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CallId.Should().Be(1);
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].NoteText.Should().Be("A");
			response[0].OfficerId.Should().Be(1);
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
				var result = await client.NoteAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>592474aec9bc4eedc410d996d01fee06</Hash>
</Codenesium>*/