using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Admin")]
	[Trait("Area", "Integration")]
	public partial class AdminIntegrationTests
	{
		public AdminIntegrationTests()
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

			var model = new ApiAdminClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B");
			var model2 = new ApiAdminClientRequestModel();
			model2.SetProperties("C", "C", "C", "C", "C", "C");
			var request = new List<ApiAdminClientRequestModel>() {model, model2};
			CreateResponse<List<ApiAdminClientResponseModel>> result = await client.AdminBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Admin>().ToList()[1].Email.Should().Be("B");
			context.Set<Admin>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Admin>().ToList()[1].LastName.Should().Be("B");
			context.Set<Admin>().ToList()[1].Password.Should().Be("B");
			context.Set<Admin>().ToList()[1].Phone.Should().Be("B");
			context.Set<Admin>().ToList()[1].Username.Should().Be("B");

			context.Set<Admin>().ToList()[2].Email.Should().Be("C");
			context.Set<Admin>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Admin>().ToList()[2].LastName.Should().Be("C");
			context.Set<Admin>().ToList()[2].Password.Should().Be("C");
			context.Set<Admin>().ToList()[2].Phone.Should().Be("C");
			context.Set<Admin>().ToList()[2].Username.Should().Be("C");
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

			var model = new ApiAdminClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B");
			CreateResponse<ApiAdminClientResponseModel> result = await client.AdminCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Admin>().ToList()[1].Email.Should().Be("B");
			context.Set<Admin>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Admin>().ToList()[1].LastName.Should().Be("B");
			context.Set<Admin>().ToList()[1].Password.Should().Be("B");
			context.Set<Admin>().ToList()[1].Phone.Should().Be("B");
			context.Set<Admin>().ToList()[1].Username.Should().Be("B");

			result.Record.Email.Should().Be("B");
			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.Password.Should().Be("B");
			result.Record.Phone.Should().Be("B");
			result.Record.Username.Should().Be("B");
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
			var mapper = new ApiAdminServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IAdminService service = testServer.Host.Services.GetService(typeof(IAdminService)) as IAdminService;
			ApiAdminServerResponseModel model = await service.Get(1);

			ApiAdminClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", "B", "B", "B");

			UpdateResponse<ApiAdminClientResponseModel> updateResponse = await client.AdminUpdateAsync(model.Id, request);

			context.Entry(context.Set<Admin>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Admin>().ToList()[0].Email.Should().Be("B");
			context.Set<Admin>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Admin>().ToList()[0].LastName.Should().Be("B");
			context.Set<Admin>().ToList()[0].Password.Should().Be("B");
			context.Set<Admin>().ToList()[0].Phone.Should().Be("B");
			context.Set<Admin>().ToList()[0].Username.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.Password.Should().Be("B");
			updateResponse.Record.Phone.Should().Be("B");
			updateResponse.Record.Username.Should().Be("B");
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

			IAdminService service = testServer.Host.Services.GetService(typeof(IAdminService)) as IAdminService;
			var model = new ApiAdminServerRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B");
			CreateResponse<ApiAdminServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.AdminDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiAdminServerResponseModel verifyResponse = await service.Get(2);

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

			ApiAdminClientResponseModel response = await client.AdminGetAsync(1);

			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
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
			ApiAdminClientResponseModel response = await client.AdminGetAsync(default(int));

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
			List<ApiAdminClientResponseModel> response = await client.AdminAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Email.Should().Be("A");
			response[0].FirstName.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastName.Should().Be("A");
			response[0].Password.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].Username.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyVenuesByAdminIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVenueClientResponseModel> response = await client.VenuesByAdminId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyVenuesByAdminIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVenueClientResponseModel> response = await client.VenuesByAdminId(default(int));

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
				var result = await client.AdminAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>9961e661ffad2ebb56b020d8dc1b6d94</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/