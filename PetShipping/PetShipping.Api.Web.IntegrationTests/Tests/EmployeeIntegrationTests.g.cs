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
	[Trait("Table", "Employee")]
	[Trait("Area", "Integration")]
	public partial class EmployeeIntegrationTests
	{
		public EmployeeIntegrationTests()
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

			var model = new ApiEmployeeClientRequestModel();
			model.SetProperties("B", true, true, "B");
			var model2 = new ApiEmployeeClientRequestModel();
			model2.SetProperties("C", true, true, "C");
			var request = new List<ApiEmployeeClientRequestModel>() {model, model2};
			CreateResponse<List<ApiEmployeeClientResponseModel>> result = await client.EmployeeBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Employee>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Employee>().ToList()[1].IsSalesPerson.Should().Be(true);
			context.Set<Employee>().ToList()[1].IsShipper.Should().Be(true);
			context.Set<Employee>().ToList()[1].LastName.Should().Be("B");

			context.Set<Employee>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Employee>().ToList()[2].IsSalesPerson.Should().Be(true);
			context.Set<Employee>().ToList()[2].IsShipper.Should().Be(true);
			context.Set<Employee>().ToList()[2].LastName.Should().Be("C");
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

			var model = new ApiEmployeeClientRequestModel();
			model.SetProperties("B", true, true, "B");
			CreateResponse<ApiEmployeeClientResponseModel> result = await client.EmployeeCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Employee>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Employee>().ToList()[1].IsSalesPerson.Should().Be(true);
			context.Set<Employee>().ToList()[1].IsShipper.Should().Be(true);
			context.Set<Employee>().ToList()[1].LastName.Should().Be("B");

			result.Record.FirstName.Should().Be("B");
			result.Record.IsSalesPerson.Should().Be(true);
			result.Record.IsShipper.Should().Be(true);
			result.Record.LastName.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiEmployeeServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IEmployeeService service = testServer.Host.Services.GetService(typeof(IEmployeeService)) as IEmployeeService;
			ApiEmployeeServerResponseModel model = await service.Get(1);

			ApiEmployeeClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", true, true, "B");

			UpdateResponse<ApiEmployeeClientResponseModel> updateResponse = await client.EmployeeUpdateAsync(model.Id, request);

			context.Entry(context.Set<Employee>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Employee>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Employee>().ToList()[0].IsSalesPerson.Should().Be(true);
			context.Set<Employee>().ToList()[0].IsShipper.Should().Be(true);
			context.Set<Employee>().ToList()[0].LastName.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.IsSalesPerson.Should().Be(true);
			updateResponse.Record.IsShipper.Should().Be(true);
			updateResponse.Record.LastName.Should().Be("B");
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

			IEmployeeService service = testServer.Host.Services.GetService(typeof(IEmployeeService)) as IEmployeeService;
			var model = new ApiEmployeeServerRequestModel();
			model.SetProperties("B", true, true, "B");
			CreateResponse<ApiEmployeeServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.EmployeeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiEmployeeServerResponseModel verifyResponse = await service.Get(2);

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

			ApiEmployeeClientResponseModel response = await client.EmployeeGetAsync(1);

			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiEmployeeClientResponseModel response = await client.EmployeeGetAsync(default(int));

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

			List<ApiEmployeeClientResponseModel> response = await client.EmployeeAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].IsSalesPerson.Should().Be(true);
			response[0].IsShipper.Should().Be(true);
			response[0].LastName.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyCustomerCommunicationsByEmployeeIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.CustomerCommunicationsByEmployeeId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCustomerCommunicationsByEmployeeIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerCommunicationClientResponseModel> response = await client.CustomerCommunicationsByEmployeeId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepsByShipperIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepClientResponseModel> response = await client.PipelineStepsByShipperId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepsByShipperIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepClientResponseModel> response = await client.PipelineStepsByShipperId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepNotesByEmployeeIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepNoteClientResponseModel> response = await client.PipelineStepNotesByEmployeeId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPipelineStepNotesByEmployeeIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPipelineStepNoteClientResponseModel> response = await client.PipelineStepNotesByEmployeeId(default(int));

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
				var result = await client.EmployeeAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>48211670ca3a263d09f5632a8e1546b3</Hash>
</Codenesium>*/