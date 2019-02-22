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
	[Trait("Table", "Officer")]
	[Trait("Area", "Integration")]
	public partial class OfficerIntegrationTests
	{
		public OfficerIntegrationTests()
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

			var model = new ApiOfficerClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			var model2 = new ApiOfficerClientRequestModel();
			model2.SetProperties("C", "C", "C", "C", "C");
			var request = new List<ApiOfficerClientRequestModel>() {model, model2};
			CreateResponse<List<ApiOfficerClientResponseModel>> result = await client.OfficerBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Officer>().ToList()[1].Badge.Should().Be("B");
			context.Set<Officer>().ToList()[1].Email.Should().Be("B");
			context.Set<Officer>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Officer>().ToList()[1].LastName.Should().Be("B");
			context.Set<Officer>().ToList()[1].Password.Should().Be("B");

			context.Set<Officer>().ToList()[2].Badge.Should().Be("C");
			context.Set<Officer>().ToList()[2].Email.Should().Be("C");
			context.Set<Officer>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Officer>().ToList()[2].LastName.Should().Be("C");
			context.Set<Officer>().ToList()[2].Password.Should().Be("C");
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

			var model = new ApiOfficerClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiOfficerClientResponseModel> result = await client.OfficerCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Officer>().ToList()[1].Badge.Should().Be("B");
			context.Set<Officer>().ToList()[1].Email.Should().Be("B");
			context.Set<Officer>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Officer>().ToList()[1].LastName.Should().Be("B");
			context.Set<Officer>().ToList()[1].Password.Should().Be("B");

			result.Record.Badge.Should().Be("B");
			result.Record.Email.Should().Be("B");
			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.Password.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiOfficerServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IOfficerService service = testServer.Host.Services.GetService(typeof(IOfficerService)) as IOfficerService;
			ApiOfficerServerResponseModel model = await service.Get(1);

			ApiOfficerClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", "B", "B");

			UpdateResponse<ApiOfficerClientResponseModel> updateResponse = await client.OfficerUpdateAsync(model.Id, request);

			context.Entry(context.Set<Officer>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Officer>().ToList()[0].Badge.Should().Be("B");
			context.Set<Officer>().ToList()[0].Email.Should().Be("B");
			context.Set<Officer>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Officer>().ToList()[0].LastName.Should().Be("B");
			context.Set<Officer>().ToList()[0].Password.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Badge.Should().Be("B");
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.Password.Should().Be("B");
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

			IOfficerService service = testServer.Host.Services.GetService(typeof(IOfficerService)) as IOfficerService;
			var model = new ApiOfficerServerRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiOfficerServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.OfficerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiOfficerServerResponseModel verifyResponse = await service.Get(2);

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

			ApiOfficerClientResponseModel response = await client.OfficerGetAsync(1);

			response.Should().NotBeNull();
			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiOfficerClientResponseModel response = await client.OfficerGetAsync(default(int));

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

			List<ApiOfficerClientResponseModel> response = await client.OfficerAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Badge.Should().Be("A");
			response[0].Email.Should().Be("A");
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastName.Should().Be("A");
			response[0].Password.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyNotesByOfficerIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiNoteClientResponseModel> response = await client.NotesByOfficerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyNotesByOfficerIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiNoteClientResponseModel> response = await client.NotesByOfficerId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyOfficerRefCapabilitiesByOfficerIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiOfficerRefCapabilityClientResponseModel> response = await client.OfficerRefCapabilitiesByOfficerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyOfficerRefCapabilitiesByOfficerIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiOfficerRefCapabilityClientResponseModel> response = await client.OfficerRefCapabilitiesByOfficerId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyUnitOfficersByOfficerIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiUnitOfficerClientResponseModel> response = await client.UnitOfficersByOfficerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyUnitOfficersByOfficerIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiUnitOfficerClientResponseModel> response = await client.UnitOfficersByOfficerId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyVehicleOfficersByOfficerIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiVehicleOfficerClientResponseModel> response = await client.VehicleOfficersByOfficerId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyVehicleOfficersByOfficerIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiVehicleOfficerClientResponseModel> response = await client.VehicleOfficersByOfficerId(default(int));

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
				var result = await client.OfficerAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>c97df13525cd6771b8a6bf0d606506ea</Hash>
</Codenesium>*/