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
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "Integration")]
	public partial class ErrorLogIntegrationTests
	{
		public ErrorLogIntegrationTests()
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

			var model = new ApiErrorLogClientRequestModel();
			model.SetProperties(2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiErrorLogClientRequestModel();
			model2.SetProperties(3, "C", 3, "C", 3, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiErrorLogClientRequestModel>() {model, model2};
			CreateResponse<List<ApiErrorLogClientResponseModel>> result = await client.ErrorLogBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ErrorLog>().ToList()[1].ErrorLine.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorMessage.Should().Be("B");
			context.Set<ErrorLog>().ToList()[1].ErrorNumber.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorProcedure.Should().Be("B");
			context.Set<ErrorLog>().ToList()[1].ErrorSeverity.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorState.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ErrorLog>().ToList()[1].UserName.Should().Be("B");

			context.Set<ErrorLog>().ToList()[2].ErrorLine.Should().Be(3);
			context.Set<ErrorLog>().ToList()[2].ErrorMessage.Should().Be("C");
			context.Set<ErrorLog>().ToList()[2].ErrorNumber.Should().Be(3);
			context.Set<ErrorLog>().ToList()[2].ErrorProcedure.Should().Be("C");
			context.Set<ErrorLog>().ToList()[2].ErrorSeverity.Should().Be(3);
			context.Set<ErrorLog>().ToList()[2].ErrorState.Should().Be(3);
			context.Set<ErrorLog>().ToList()[2].ErrorTime.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ErrorLog>().ToList()[2].UserName.Should().Be("C");
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

			var model = new ApiErrorLogClientRequestModel();
			model.SetProperties(2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiErrorLogClientResponseModel> result = await client.ErrorLogCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ErrorLog>().ToList()[1].ErrorLine.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorMessage.Should().Be("B");
			context.Set<ErrorLog>().ToList()[1].ErrorNumber.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorProcedure.Should().Be("B");
			context.Set<ErrorLog>().ToList()[1].ErrorSeverity.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorState.Should().Be(2);
			context.Set<ErrorLog>().ToList()[1].ErrorTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ErrorLog>().ToList()[1].UserName.Should().Be("B");

			result.Record.ErrorLine.Should().Be(2);
			result.Record.ErrorMessage.Should().Be("B");
			result.Record.ErrorNumber.Should().Be(2);
			result.Record.ErrorProcedure.Should().Be("B");
			result.Record.ErrorSeverity.Should().Be(2);
			result.Record.ErrorState.Should().Be(2);
			result.Record.ErrorTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.UserName.Should().Be("B");
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
			var mapper = new ApiErrorLogServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IErrorLogService service = testServer.Host.Services.GetService(typeof(IErrorLogService)) as IErrorLogService;
			ApiErrorLogServerResponseModel model = await service.Get(1);

			ApiErrorLogClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiErrorLogClientResponseModel> updateResponse = await client.ErrorLogUpdateAsync(model.ErrorLogID, request);

			context.Entry(context.Set<ErrorLog>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ErrorLogID.Should().Be(1);
			context.Set<ErrorLog>().ToList()[0].ErrorLine.Should().Be(2);
			context.Set<ErrorLog>().ToList()[0].ErrorMessage.Should().Be("B");
			context.Set<ErrorLog>().ToList()[0].ErrorNumber.Should().Be(2);
			context.Set<ErrorLog>().ToList()[0].ErrorProcedure.Should().Be("B");
			context.Set<ErrorLog>().ToList()[0].ErrorSeverity.Should().Be(2);
			context.Set<ErrorLog>().ToList()[0].ErrorState.Should().Be(2);
			context.Set<ErrorLog>().ToList()[0].ErrorTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ErrorLog>().ToList()[0].UserName.Should().Be("B");

			updateResponse.Record.ErrorLogID.Should().Be(1);
			updateResponse.Record.ErrorLine.Should().Be(2);
			updateResponse.Record.ErrorMessage.Should().Be("B");
			updateResponse.Record.ErrorNumber.Should().Be(2);
			updateResponse.Record.ErrorProcedure.Should().Be("B");
			updateResponse.Record.ErrorSeverity.Should().Be(2);
			updateResponse.Record.ErrorState.Should().Be(2);
			updateResponse.Record.ErrorTime.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.UserName.Should().Be("B");
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

			IErrorLogService service = testServer.Host.Services.GetService(typeof(IErrorLogService)) as IErrorLogService;
			var model = new ApiErrorLogServerRequestModel();
			model.SetProperties(2, "B", 2, "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiErrorLogServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ErrorLogDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiErrorLogServerResponseModel verifyResponse = await service.Get(2);

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

			ApiErrorLogClientResponseModel response = await client.ErrorLogGetAsync(1);

			response.Should().NotBeNull();
			response.ErrorLine.Should().Be(1);
			response.ErrorLogID.Should().Be(1);
			response.ErrorMessage.Should().Be("A");
			response.ErrorNumber.Should().Be(1);
			response.ErrorProcedure.Should().Be("A");
			response.ErrorSeverity.Should().Be(1);
			response.ErrorState.Should().Be(1);
			response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UserName.Should().Be("A");
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
			ApiErrorLogClientResponseModel response = await client.ErrorLogGetAsync(default(int));

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
			List<ApiErrorLogClientResponseModel> response = await client.ErrorLogAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ErrorLine.Should().Be(1);
			response[0].ErrorLogID.Should().Be(1);
			response[0].ErrorMessage.Should().Be("A");
			response[0].ErrorNumber.Should().Be(1);
			response[0].ErrorProcedure.Should().Be("A");
			response[0].ErrorSeverity.Should().Be(1);
			response[0].ErrorState.Should().Be(1);
			response[0].ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].UserName.Should().Be("A");
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
				var result = await client.ErrorLogAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>fb623f85bfbf4acb3f20e2e43f811270</Hash>
</Codenesium>*/