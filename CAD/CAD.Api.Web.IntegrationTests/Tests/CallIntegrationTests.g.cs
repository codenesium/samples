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
	[Trait("Table", "Call")]
	[Trait("Area", "Integration")]
	public partial class CallIntegrationTests
	{
		public CallIntegrationTests()
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

			var model = new ApiCallClientRequestModel();
			model.SetProperties(1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			var model2 = new ApiCallClientRequestModel();
			model2.SetProperties(1, 1, 1, "C", 1, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3);
			var request = new List<ApiCallClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCallClientResponseModel>> result = await client.CallBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Call>().ToList()[1].AddressId.Should().Be(1);
			context.Set<Call>().ToList()[1].CallDispositionId.Should().Be(1);
			context.Set<Call>().ToList()[1].CallStatusId.Should().Be(1);
			context.Set<Call>().ToList()[1].CallString.Should().Be("B");
			context.Set<Call>().ToList()[1].CallTypeId.Should().Be(1);
			context.Set<Call>().ToList()[1].DateCleared.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[1].DateDispatched.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[1].QuickCallNumber.Should().Be(2);

			context.Set<Call>().ToList()[2].AddressId.Should().Be(1);
			context.Set<Call>().ToList()[2].CallDispositionId.Should().Be(1);
			context.Set<Call>().ToList()[2].CallStatusId.Should().Be(1);
			context.Set<Call>().ToList()[2].CallString.Should().Be("C");
			context.Set<Call>().ToList()[2].CallTypeId.Should().Be(1);
			context.Set<Call>().ToList()[2].DateCleared.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Call>().ToList()[2].DateCreated.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Call>().ToList()[2].DateDispatched.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Call>().ToList()[2].QuickCallNumber.Should().Be(3);
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

			var model = new ApiCallClientRequestModel();
			model.SetProperties(1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiCallClientResponseModel> result = await client.CallCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Call>().ToList()[1].AddressId.Should().Be(1);
			context.Set<Call>().ToList()[1].CallDispositionId.Should().Be(1);
			context.Set<Call>().ToList()[1].CallStatusId.Should().Be(1);
			context.Set<Call>().ToList()[1].CallString.Should().Be("B");
			context.Set<Call>().ToList()[1].CallTypeId.Should().Be(1);
			context.Set<Call>().ToList()[1].DateCleared.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[1].DateDispatched.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[1].QuickCallNumber.Should().Be(2);

			result.Record.AddressId.Should().Be(1);
			result.Record.CallDispositionId.Should().Be(1);
			result.Record.CallStatusId.Should().Be(1);
			result.Record.CallString.Should().Be("B");
			result.Record.CallTypeId.Should().Be(1);
			result.Record.DateCleared.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.DateDispatched.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.QuickCallNumber.Should().Be(2);
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
			var mapper = new ApiCallServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICallService service = testServer.Host.Services.GetService(typeof(ICallService)) as ICallService;
			ApiCallServerResponseModel model = await service.Get(1);

			ApiCallClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);

			UpdateResponse<ApiCallClientResponseModel> updateResponse = await client.CallUpdateAsync(model.Id, request);

			context.Entry(context.Set<Call>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Call>().ToList()[0].AddressId.Should().Be(1);
			context.Set<Call>().ToList()[0].CallDispositionId.Should().Be(1);
			context.Set<Call>().ToList()[0].CallStatusId.Should().Be(1);
			context.Set<Call>().ToList()[0].CallString.Should().Be("B");
			context.Set<Call>().ToList()[0].CallTypeId.Should().Be(1);
			context.Set<Call>().ToList()[0].DateCleared.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[0].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[0].DateDispatched.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Call>().ToList()[0].QuickCallNumber.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.AddressId.Should().Be(1);
			updateResponse.Record.CallDispositionId.Should().Be(1);
			updateResponse.Record.CallStatusId.Should().Be(1);
			updateResponse.Record.CallString.Should().Be("B");
			updateResponse.Record.CallTypeId.Should().Be(1);
			updateResponse.Record.DateCleared.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.DateDispatched.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.QuickCallNumber.Should().Be(2);
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

			ICallService service = testServer.Host.Services.GetService(typeof(ICallService)) as ICallService;
			var model = new ApiCallServerRequestModel();
			model.SetProperties(1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiCallServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CallDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCallServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCallClientResponseModel response = await client.CallGetAsync(1);

			response.Should().NotBeNull();
			response.AddressId.Should().Be(1);
			response.CallDispositionId.Should().Be(1);
			response.CallStatusId.Should().Be(1);
			response.CallString.Should().Be("A");
			response.CallTypeId.Should().Be(1);
			response.DateCleared.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateDispatched.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.QuickCallNumber.Should().Be(1);
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
			ApiCallClientResponseModel response = await client.CallGetAsync(default(int));

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
			List<ApiCallClientResponseModel> response = await client.CallAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AddressId.Should().Be(1);
			response[0].CallDispositionId.Should().Be(1);
			response[0].CallStatusId.Should().Be(1);
			response[0].CallString.Should().Be("A");
			response[0].CallTypeId.Should().Be(1);
			response[0].DateCleared.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].DateDispatched.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].QuickCallNumber.Should().Be(1);
		}

		[Fact]
		public virtual async void TestForeignKeyNotesByCallIdFound()
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
			List<ApiNoteClientResponseModel> response = await client.NotesByCallId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyNotesByCallIdNotFound()
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
			List<ApiNoteClientResponseModel> response = await client.NotesByCallId(default(int));

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
				var result = await client.CallAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>fc39c9c8a8c015a6493875fe49910996</Hash>
</Codenesium>*/