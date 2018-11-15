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
	[Trait("Table", "Client")]
	[Trait("Area", "Integration")]
	public partial class ClientIntegrationTests
	{
		public ClientIntegrationTests()
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

			var model = new ApiClientClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			var model2 = new ApiClientClientRequestModel();
			model2.SetProperties("C", "C", "C", "C", "C");
			var request = new List<ApiClientClientRequestModel>() {model, model2};
			CreateResponse<List<ApiClientClientResponseModel>> result = await client.ClientBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Client>().ToList()[1].Email.Should().Be("B");
			context.Set<Client>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Client>().ToList()[1].LastName.Should().Be("B");
			context.Set<Client>().ToList()[1].Note.Should().Be("B");
			context.Set<Client>().ToList()[1].Phone.Should().Be("B");

			context.Set<Client>().ToList()[2].Email.Should().Be("C");
			context.Set<Client>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Client>().ToList()[2].LastName.Should().Be("C");
			context.Set<Client>().ToList()[2].Note.Should().Be("C");
			context.Set<Client>().ToList()[2].Phone.Should().Be("C");
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

			var model = new ApiClientClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiClientClientResponseModel> result = await client.ClientCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Client>().ToList()[1].Email.Should().Be("B");
			context.Set<Client>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Client>().ToList()[1].LastName.Should().Be("B");
			context.Set<Client>().ToList()[1].Note.Should().Be("B");
			context.Set<Client>().ToList()[1].Phone.Should().Be("B");

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
			var mapper = new ApiClientServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IClientService service = testServer.Host.Services.GetService(typeof(IClientService)) as IClientService;
			ApiClientServerResponseModel model = await service.Get(1);

			ApiClientClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", "B", "B");

			UpdateResponse<ApiClientClientResponseModel> updateResponse = await client.ClientUpdateAsync(model.Id, request);

			context.Entry(context.Set<Client>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Client>().ToList()[0].Email.Should().Be("B");
			context.Set<Client>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Client>().ToList()[0].LastName.Should().Be("B");
			context.Set<Client>().ToList()[0].Note.Should().Be("B");
			context.Set<Client>().ToList()[0].Phone.Should().Be("B");

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

			IClientService service = testServer.Host.Services.GetService(typeof(IClientService)) as IClientService;
			var model = new ApiClientServerRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiClientServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ClientDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiClientServerResponseModel verifyResponse = await service.Get(2);

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

			ApiClientClientResponseModel response = await client.ClientGetAsync(1);

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
			ApiClientClientResponseModel response = await client.ClientGetAsync(default(int));

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

			List<ApiClientClientResponseModel> response = await client.ClientAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Email.Should().Be("A");
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastName.Should().Be("A");
			response[0].Note.Should().Be("A");
			response[0].Phone.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyClientCommunicationsByClientIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiClientCommunicationClientResponseModel> response = await client.ClientCommunicationsByClientId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyClientCommunicationsByClientIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiClientCommunicationClientResponseModel> response = await client.ClientCommunicationsByClientId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPetsByClientIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPetClientResponseModel> response = await client.PetsByClientId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPetsByClientIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPetClientResponseModel> response = await client.PetsByClientId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesByClientIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSaleClientResponseModel> response = await client.SalesByClientId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesByClientIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSaleClientResponseModel> response = await client.SalesByClientId(default(int));

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
				var result = await client.ClientAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>aff2932cd22fe7c13e8a67ed9554d8c5</Hash>
</Codenesium>*/