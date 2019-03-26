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
	[Trait("Table", "CallPerson")]
	[Trait("Area", "Integration")]
	public partial class CallPersonIntegrationTests
	{
		public CallPersonIntegrationTests()
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

			var model = new ApiCallPersonClientRequestModel();
			model.SetProperties("B", 1, 1);
			var model2 = new ApiCallPersonClientRequestModel();
			model2.SetProperties("C", 1, 1);
			var request = new List<ApiCallPersonClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCallPersonClientResponseModel>> result = await client.CallPersonBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<CallPerson>().ToList()[1].Note.Should().Be("B");
			context.Set<CallPerson>().ToList()[1].PersonId.Should().Be(1);
			context.Set<CallPerson>().ToList()[1].PersonTypeId.Should().Be(1);

			context.Set<CallPerson>().ToList()[2].Note.Should().Be("C");
			context.Set<CallPerson>().ToList()[2].PersonId.Should().Be(1);
			context.Set<CallPerson>().ToList()[2].PersonTypeId.Should().Be(1);
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

			var model = new ApiCallPersonClientRequestModel();
			model.SetProperties("B", 1, 1);
			CreateResponse<ApiCallPersonClientResponseModel> result = await client.CallPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<CallPerson>().ToList()[1].Note.Should().Be("B");
			context.Set<CallPerson>().ToList()[1].PersonId.Should().Be(1);
			context.Set<CallPerson>().ToList()[1].PersonTypeId.Should().Be(1);

			result.Record.Note.Should().Be("B");
			result.Record.PersonId.Should().Be(1);
			result.Record.PersonTypeId.Should().Be(1);
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
			var mapper = new ApiCallPersonServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICallPersonService service = testServer.Host.Services.GetService(typeof(ICallPersonService)) as ICallPersonService;
			ApiCallPersonServerResponseModel model = await service.Get(1);

			ApiCallPersonClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 1, 1);

			UpdateResponse<ApiCallPersonClientResponseModel> updateResponse = await client.CallPersonUpdateAsync(model.Id, request);

			context.Entry(context.Set<CallPerson>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<CallPerson>().ToList()[0].Note.Should().Be("B");
			context.Set<CallPerson>().ToList()[0].PersonId.Should().Be(1);
			context.Set<CallPerson>().ToList()[0].PersonTypeId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Note.Should().Be("B");
			updateResponse.Record.PersonId.Should().Be(1);
			updateResponse.Record.PersonTypeId.Should().Be(1);
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

			ICallPersonService service = testServer.Host.Services.GetService(typeof(ICallPersonService)) as ICallPersonService;
			var model = new ApiCallPersonServerRequestModel();
			model.SetProperties("B", 1, 1);
			CreateResponse<ApiCallPersonServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CallPersonDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCallPersonServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCallPersonClientResponseModel response = await client.CallPersonGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
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
			ApiCallPersonClientResponseModel response = await client.CallPersonGetAsync(default(int));

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
			List<ApiCallPersonClientResponseModel> response = await client.CallPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Note.Should().Be("A");
			response[0].PersonId.Should().Be(1);
			response[0].PersonTypeId.Should().Be(1);
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
				var result = await client.CallPersonAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>8ad6de69b7c6025d1943157ecb247a4c</Hash>
</Codenesium>*/