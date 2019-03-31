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
	[Trait("Table", "Person")]
	[Trait("Area", "Integration")]
	public partial class PersonIntegrationTests
	{
		public PersonIntegrationTests()
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

			var model = new ApiPersonClientRequestModel();
			model.SetProperties("B", "B", "B", "B");
			var model2 = new ApiPersonClientRequestModel();
			model2.SetProperties("C", "C", "C", "C");
			var request = new List<ApiPersonClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPersonClientResponseModel>> result = await client.PersonBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Person>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Person>().ToList()[1].LastName.Should().Be("B");
			context.Set<Person>().ToList()[1].Phone.Should().Be("B");
			context.Set<Person>().ToList()[1].Ssn.Should().Be("B");

			context.Set<Person>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Person>().ToList()[2].LastName.Should().Be("C");
			context.Set<Person>().ToList()[2].Phone.Should().Be("C");
			context.Set<Person>().ToList()[2].Ssn.Should().Be("C");
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

			var model = new ApiPersonClientRequestModel();
			model.SetProperties("B", "B", "B", "B");
			CreateResponse<ApiPersonClientResponseModel> result = await client.PersonCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Person>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Person>().ToList()[1].LastName.Should().Be("B");
			context.Set<Person>().ToList()[1].Phone.Should().Be("B");
			context.Set<Person>().ToList()[1].Ssn.Should().Be("B");

			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.Phone.Should().Be("B");
			result.Record.Ssn.Should().Be("B");
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
			var mapper = new ApiPersonServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPersonService service = testServer.Host.Services.GetService(typeof(IPersonService)) as IPersonService;
			ApiPersonServerResponseModel model = await service.Get(1);

			ApiPersonClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", "B");

			UpdateResponse<ApiPersonClientResponseModel> updateResponse = await client.PersonUpdateAsync(model.Id, request);

			context.Entry(context.Set<Person>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Person>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Person>().ToList()[0].LastName.Should().Be("B");
			context.Set<Person>().ToList()[0].Phone.Should().Be("B");
			context.Set<Person>().ToList()[0].Ssn.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.Phone.Should().Be("B");
			updateResponse.Record.Ssn.Should().Be("B");
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

			IPersonService service = testServer.Host.Services.GetService(typeof(IPersonService)) as IPersonService;
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("B", "B", "B", "B");
			CreateResponse<ApiPersonServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PersonDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPersonServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPersonClientResponseModel response = await client.PersonGetAsync(1);

			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
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
			ApiPersonClientResponseModel response = await client.PersonGetAsync(default(int));

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
			List<ApiPersonClientResponseModel> response = await client.PersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastName.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].Ssn.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyCallPersonsByPersonIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCallPersonClientResponseModel> response = await client.CallPersonsByPersonId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCallPersonsByPersonIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCallPersonClientResponseModel> response = await client.CallPersonsByPersonId(default(int));

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
				var result = await client.PersonAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>0bcdddccbf3f2cc3fe1de85d62b4115e</Hash>
</Codenesium>*/