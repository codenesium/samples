using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "Integration")]
	public partial class CustomerCommunicationIntegrationTests
	{
		public CustomerCommunicationIntegrationTests()
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

			var model = new ApiCustomerCommunicationClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			var model2 = new ApiCustomerCommunicationClientRequestModel();
			model2.SetProperties(1, DateTime.Parse("1/1/1989 12:00:00 AM"), 1, "C");
			var request = new List<ApiCustomerCommunicationClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCustomerCommunicationClientResponseModel>> result = await client.CustomerCommunicationBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<CustomerCommunication>().ToList()[1].CustomerId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CustomerCommunication>().ToList()[1].EmployeeId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[1].Notes.Should().Be("B");

			context.Set<CustomerCommunication>().ToList()[2].CustomerId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[2].DateCreated.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<CustomerCommunication>().ToList()[2].EmployeeId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[2].Notes.Should().Be("C");
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

			var model = new ApiCustomerCommunicationClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiCustomerCommunicationClientResponseModel> result = await client.CustomerCommunicationCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<CustomerCommunication>().ToList()[1].CustomerId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CustomerCommunication>().ToList()[1].EmployeeId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[1].Notes.Should().Be("B");

			result.Record.CustomerId.Should().Be(1);
			result.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.EmployeeId.Should().Be(1);
			result.Record.Notes.Should().Be("B");
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
			var mapper = new ApiCustomerCommunicationServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICustomerCommunicationService service = testServer.Host.Services.GetService(typeof(ICustomerCommunicationService)) as ICustomerCommunicationService;
			ApiCustomerCommunicationServerResponseModel model = await service.Get(1);

			ApiCustomerCommunicationClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");

			UpdateResponse<ApiCustomerCommunicationClientResponseModel> updateResponse = await client.CustomerCommunicationUpdateAsync(model.Id, request);

			context.Entry(context.Set<CustomerCommunication>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[0].CustomerId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[0].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CustomerCommunication>().ToList()[0].EmployeeId.Should().Be(1);
			context.Set<CustomerCommunication>().ToList()[0].Notes.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CustomerId.Should().Be(1);
			updateResponse.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.EmployeeId.Should().Be(1);
			updateResponse.Record.Notes.Should().Be("B");
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

			ICustomerCommunicationService service = testServer.Host.Services.GetService(typeof(ICustomerCommunicationService)) as ICustomerCommunicationService;
			var model = new ApiCustomerCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiCustomerCommunicationServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CustomerCommunicationDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCustomerCommunicationServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCustomerCommunicationClientResponseModel response = await client.CustomerCommunicationGetAsync(1);

			response.Should().NotBeNull();
			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
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
			ApiCustomerCommunicationClientResponseModel response = await client.CustomerCommunicationGetAsync(default(int));

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
			List<ApiCustomerCommunicationClientResponseModel> response = await client.CustomerCommunicationAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CustomerId.Should().Be(1);
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].EmployeeId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Notes.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByCustomerIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.ByCustomerCommunicationByCustomerId(1);

			response.Should().NotBeEmpty();
			response[0].CustomerId.Should().Be(1);
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].EmployeeId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Notes.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByCustomerIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.ByCustomerCommunicationByCustomerId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByEmployeeIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.ByCustomerCommunicationByEmployeeId(1);

			response.Should().NotBeEmpty();
			response[0].CustomerId.Should().Be(1);
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].EmployeeId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Notes.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByEmployeeIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.ByCustomerCommunicationByEmployeeId(default(int));

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
				var result = await client.CustomerCommunicationAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>a54328a50acf718f0286a4a28493d09b</Hash>
</Codenesium>*/