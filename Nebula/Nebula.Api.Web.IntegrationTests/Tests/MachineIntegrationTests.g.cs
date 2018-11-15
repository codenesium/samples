using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Machine")]
	[Trait("Area", "Integration")]
	public partial class MachineIntegrationTests
	{
		public MachineIntegrationTests()
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

			var model = new ApiMachineClientRequestModel();
			model.SetProperties("B", "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			var model2 = new ApiMachineClientRequestModel();
			model2.SetProperties("C", "C", "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), "C");
			var request = new List<ApiMachineClientRequestModel>() {model, model2};
			CreateResponse<List<ApiMachineClientResponseModel>> result = await client.MachineBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Machine>().ToList()[1].Description.Should().Be("B");
			context.Set<Machine>().ToList()[1].JwtKey.Should().Be("B");
			context.Set<Machine>().ToList()[1].LastIpAddress.Should().Be("B");
			context.Set<Machine>().ToList()[1].MachineGuid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Machine>().ToList()[1].Name.Should().Be("B");

			context.Set<Machine>().ToList()[2].Description.Should().Be("C");
			context.Set<Machine>().ToList()[2].JwtKey.Should().Be("C");
			context.Set<Machine>().ToList()[2].LastIpAddress.Should().Be("C");
			context.Set<Machine>().ToList()[2].MachineGuid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Machine>().ToList()[2].Name.Should().Be("C");
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

			var model = new ApiMachineClientRequestModel();
			model.SetProperties("B", "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiMachineClientResponseModel> result = await client.MachineCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Machine>().ToList()[1].Description.Should().Be("B");
			context.Set<Machine>().ToList()[1].JwtKey.Should().Be("B");
			context.Set<Machine>().ToList()[1].LastIpAddress.Should().Be("B");
			context.Set<Machine>().ToList()[1].MachineGuid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Machine>().ToList()[1].Name.Should().Be("B");

			result.Record.Description.Should().Be("B");
			result.Record.JwtKey.Should().Be("B");
			result.Record.LastIpAddress.Should().Be("B");
			result.Record.MachineGuid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.Name.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiMachineServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IMachineService service = testServer.Host.Services.GetService(typeof(IMachineService)) as IMachineService;
			ApiMachineServerResponseModel model = await service.Get(1);

			ApiMachineClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");

			UpdateResponse<ApiMachineClientResponseModel> updateResponse = await client.MachineUpdateAsync(model.Id, request);

			context.Entry(context.Set<Machine>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Machine>().ToList()[0].Description.Should().Be("B");
			context.Set<Machine>().ToList()[0].JwtKey.Should().Be("B");
			context.Set<Machine>().ToList()[0].LastIpAddress.Should().Be("B");
			context.Set<Machine>().ToList()[0].MachineGuid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Machine>().ToList()[0].Name.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.JwtKey.Should().Be("B");
			updateResponse.Record.LastIpAddress.Should().Be("B");
			updateResponse.Record.MachineGuid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.Name.Should().Be("B");
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

			IMachineService service = testServer.Host.Services.GetService(typeof(IMachineService)) as IMachineService;
			var model = new ApiMachineServerRequestModel();
			model.SetProperties("B", "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiMachineServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.MachineDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiMachineServerResponseModel verifyResponse = await service.Get(2);

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

			ApiMachineClientResponseModel response = await client.MachineGetAsync(1);

			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiMachineClientResponseModel response = await client.MachineGetAsync(default(int));

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

			List<ApiMachineClientResponseModel> response = await client.MachineAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Description.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].JwtKey.Should().Be("A");
			response[0].LastIpAddress.Should().Be("A");
			response[0].MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByMachineGuidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiMachineClientResponseModel response = await client.ByMachineByMachineGuid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByMachineGuidNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiMachineClientResponseModel response = await client.ByMachineByMachineGuid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeyLinksByAssignedMachineIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiLinkClientResponseModel> response = await client.LinksByAssignedMachineId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyLinksByAssignedMachineIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiLinkClientResponseModel> response = await client.LinksByAssignedMachineId(default(int));

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
				var result = await client.MachineAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>7b7334759dd5dd5f62d65971243ff8ab</Hash>
</Codenesium>*/