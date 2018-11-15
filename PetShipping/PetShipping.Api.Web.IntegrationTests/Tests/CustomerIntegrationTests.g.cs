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
	[Trait("Table", "Customer")]
	[Trait("Area", "Integration")]
	public partial class CustomerIntegrationTests
	{
		public CustomerIntegrationTests()
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

			var model = new ApiCustomerClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			var model2 = new ApiCustomerClientRequestModel();
			model2.SetProperties("C", "C", "C", "C", "C");
			var request = new List<ApiCustomerClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCustomerClientResponseModel>> result = await client.CustomerBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Customer>().ToList()[1].Email.Should().Be("B");
			context.Set<Customer>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Customer>().ToList()[1].LastName.Should().Be("B");
			context.Set<Customer>().ToList()[1].Note.Should().Be("B");
			context.Set<Customer>().ToList()[1].Phone.Should().Be("B");

			context.Set<Customer>().ToList()[2].Email.Should().Be("C");
			context.Set<Customer>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Customer>().ToList()[2].LastName.Should().Be("C");
			context.Set<Customer>().ToList()[2].Note.Should().Be("C");
			context.Set<Customer>().ToList()[2].Phone.Should().Be("C");
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

			var model = new ApiCustomerClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiCustomerClientResponseModel> result = await client.CustomerCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Customer>().ToList()[1].Email.Should().Be("B");
			context.Set<Customer>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Customer>().ToList()[1].LastName.Should().Be("B");
			context.Set<Customer>().ToList()[1].Note.Should().Be("B");
			context.Set<Customer>().ToList()[1].Phone.Should().Be("B");

			result.Record.Email.Should().Be("B");
			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.Note.Should().Be("B");
			result.Record.Phone.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiCustomerServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICustomerService service = testServer.Host.Services.GetService(typeof(ICustomerService)) as ICustomerService;
			ApiCustomerServerResponseModel model = await service.Get(1);

			ApiCustomerClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", "B", "B");

			UpdateResponse<ApiCustomerClientResponseModel> updateResponse = await client.CustomerUpdateAsync(model.Id, request);

			context.Entry(context.Set<Customer>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Customer>().ToList()[0].Email.Should().Be("B");
			context.Set<Customer>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Customer>().ToList()[0].LastName.Should().Be("B");
			context.Set<Customer>().ToList()[0].Note.Should().Be("B");
			context.Set<Customer>().ToList()[0].Phone.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.Note.Should().Be("B");
			updateResponse.Record.Phone.Should().Be("B");
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

			ICustomerService service = testServer.Host.Services.GetService(typeof(ICustomerService)) as ICustomerService;
			var model = new ApiCustomerServerRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiCustomerServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CustomerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCustomerServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCustomerClientResponseModel response = await client.CustomerGetAsync(1);

			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCustomerClientResponseModel response = await client.CustomerGetAsync(default(int));

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

			List<ApiCustomerClientResponseModel> response = await client.CustomerAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Email.Should().Be("A");
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastName.Should().Be("A");
			response[0].Note.Should().Be("A");
			response[0].Phone.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyCustomerCommunicationsByCustomerIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.CustomerCommunicationsByCustomerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCustomerCommunicationsByCustomerIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.CustomerCommunicationsByCustomerId(default(int));

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
				var result = await client.CustomerAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>0a06d389c5a842cd591a6cf8b2522f8a</Hash>
</Codenesium>*/