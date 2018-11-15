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
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "Integration")]
	public partial class ClientCommunicationIntegrationTests
	{
		public ClientCommunicationIntegrationTests()
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

			var model = new ApiClientCommunicationClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			var model2 = new ApiClientCommunicationClientRequestModel();
			model2.SetProperties(1, DateTime.Parse("1/1/1989 12:00:00 AM"), 1, "C");
			var request = new List<ApiClientCommunicationClientRequestModel>() {model, model2};
			CreateResponse<List<ApiClientCommunicationClientResponseModel>> result = await client.ClientCommunicationBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ClientCommunication>().ToList()[1].ClientId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ClientCommunication>().ToList()[1].EmployeeId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[1].Note.Should().Be("B");

			context.Set<ClientCommunication>().ToList()[2].ClientId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[2].DateCreated.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ClientCommunication>().ToList()[2].EmployeeId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[2].Note.Should().Be("C");
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

			var model = new ApiClientCommunicationClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiClientCommunicationClientResponseModel> result = await client.ClientCommunicationCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ClientCommunication>().ToList()[1].ClientId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ClientCommunication>().ToList()[1].EmployeeId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[1].Note.Should().Be("B");

			result.Record.ClientId.Should().Be(1);
			result.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.EmployeeId.Should().Be(1);
			result.Record.Note.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiClientCommunicationServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IClientCommunicationService service = testServer.Host.Services.GetService(typeof(IClientCommunicationService)) as IClientCommunicationService;
			ApiClientCommunicationServerResponseModel model = await service.Get(1);

			ApiClientCommunicationClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");

			UpdateResponse<ApiClientCommunicationClientResponseModel> updateResponse = await client.ClientCommunicationUpdateAsync(model.Id, request);

			context.Entry(context.Set<ClientCommunication>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[0].ClientId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[0].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ClientCommunication>().ToList()[0].EmployeeId.Should().Be(1);
			context.Set<ClientCommunication>().ToList()[0].Note.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.ClientId.Should().Be(1);
			updateResponse.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.EmployeeId.Should().Be(1);
			updateResponse.Record.Note.Should().Be("B");
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

			IClientCommunicationService service = testServer.Host.Services.GetService(typeof(IClientCommunicationService)) as IClientCommunicationService;
			var model = new ApiClientCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiClientCommunicationServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ClientCommunicationDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiClientCommunicationServerResponseModel verifyResponse = await service.Get(2);

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

			ApiClientCommunicationClientResponseModel response = await client.ClientCommunicationGetAsync(1);

			response.Should().NotBeNull();
			response.ClientId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiClientCommunicationClientResponseModel response = await client.ClientCommunicationGetAsync(default(int));

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

			List<ApiClientCommunicationClientResponseModel> response = await client.ClientCommunicationAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ClientId.Should().Be(1);
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].EmployeeId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Note.Should().Be("A");
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
				var result = await client.ClientCommunicationAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>01e1cbe140d764de89f5c84767866c51</Hash>
</Codenesium>*/