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
	[Trait("Table", "Venue")]
	[Trait("Area", "Integration")]
	public partial class VenueIntegrationTests
	{
		public VenueIntegrationTests()
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

			var model = new ApiVenueClientRequestModel();
			model.SetProperties("B", "B", 1, "B", "B", "B", "B", 1, "B");
			var model2 = new ApiVenueClientRequestModel();
			model2.SetProperties("C", "C", 1, "C", "C", "C", "C", 1, "C");
			var request = new List<ApiVenueClientRequestModel>() {model, model2};
			CreateResponse<List<ApiVenueClientResponseModel>> result = await client.VenueBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Venue>().ToList()[1].Address1.Should().Be("B");
			context.Set<Venue>().ToList()[1].Address2.Should().Be("B");
			context.Set<Venue>().ToList()[1].AdminId.Should().Be(1);
			context.Set<Venue>().ToList()[1].Email.Should().Be("B");
			context.Set<Venue>().ToList()[1].Facebook.Should().Be("B");
			context.Set<Venue>().ToList()[1].Name.Should().Be("B");
			context.Set<Venue>().ToList()[1].Phone.Should().Be("B");
			context.Set<Venue>().ToList()[1].ProvinceId.Should().Be(1);
			context.Set<Venue>().ToList()[1].Website.Should().Be("B");

			context.Set<Venue>().ToList()[2].Address1.Should().Be("C");
			context.Set<Venue>().ToList()[2].Address2.Should().Be("C");
			context.Set<Venue>().ToList()[2].AdminId.Should().Be(1);
			context.Set<Venue>().ToList()[2].Email.Should().Be("C");
			context.Set<Venue>().ToList()[2].Facebook.Should().Be("C");
			context.Set<Venue>().ToList()[2].Name.Should().Be("C");
			context.Set<Venue>().ToList()[2].Phone.Should().Be("C");
			context.Set<Venue>().ToList()[2].ProvinceId.Should().Be(1);
			context.Set<Venue>().ToList()[2].Website.Should().Be("C");
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

			var model = new ApiVenueClientRequestModel();
			model.SetProperties("B", "B", 1, "B", "B", "B", "B", 1, "B");
			CreateResponse<ApiVenueClientResponseModel> result = await client.VenueCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Venue>().ToList()[1].Address1.Should().Be("B");
			context.Set<Venue>().ToList()[1].Address2.Should().Be("B");
			context.Set<Venue>().ToList()[1].AdminId.Should().Be(1);
			context.Set<Venue>().ToList()[1].Email.Should().Be("B");
			context.Set<Venue>().ToList()[1].Facebook.Should().Be("B");
			context.Set<Venue>().ToList()[1].Name.Should().Be("B");
			context.Set<Venue>().ToList()[1].Phone.Should().Be("B");
			context.Set<Venue>().ToList()[1].ProvinceId.Should().Be(1);
			context.Set<Venue>().ToList()[1].Website.Should().Be("B");

			result.Record.Address1.Should().Be("B");
			result.Record.Address2.Should().Be("B");
			result.Record.AdminId.Should().Be(1);
			result.Record.Email.Should().Be("B");
			result.Record.Facebook.Should().Be("B");
			result.Record.Name.Should().Be("B");
			result.Record.Phone.Should().Be("B");
			result.Record.ProvinceId.Should().Be(1);
			result.Record.Website.Should().Be("B");
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
			var mapper = new ApiVenueServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IVenueService service = testServer.Host.Services.GetService(typeof(IVenueService)) as IVenueService;
			ApiVenueServerResponseModel model = await service.Get(1);

			ApiVenueClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", 1, "B", "B", "B", "B", 1, "B");

			UpdateResponse<ApiVenueClientResponseModel> updateResponse = await client.VenueUpdateAsync(model.Id, request);

			context.Entry(context.Set<Venue>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Venue>().ToList()[0].Address1.Should().Be("B");
			context.Set<Venue>().ToList()[0].Address2.Should().Be("B");
			context.Set<Venue>().ToList()[0].AdminId.Should().Be(1);
			context.Set<Venue>().ToList()[0].Email.Should().Be("B");
			context.Set<Venue>().ToList()[0].Facebook.Should().Be("B");
			context.Set<Venue>().ToList()[0].Name.Should().Be("B");
			context.Set<Venue>().ToList()[0].Phone.Should().Be("B");
			context.Set<Venue>().ToList()[0].ProvinceId.Should().Be(1);
			context.Set<Venue>().ToList()[0].Website.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Address1.Should().Be("B");
			updateResponse.Record.Address2.Should().Be("B");
			updateResponse.Record.AdminId.Should().Be(1);
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.Facebook.Should().Be("B");
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Phone.Should().Be("B");
			updateResponse.Record.ProvinceId.Should().Be(1);
			updateResponse.Record.Website.Should().Be("B");
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

			IVenueService service = testServer.Host.Services.GetService(typeof(IVenueService)) as IVenueService;
			var model = new ApiVenueServerRequestModel();
			model.SetProperties("B", "B", 1, "B", "B", "B", "B", 1, "B");
			CreateResponse<ApiVenueServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.VenueDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiVenueServerResponseModel verifyResponse = await service.Get(2);

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

			ApiVenueClientResponseModel response = await client.VenueGetAsync(1);

			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.AdminId.Should().Be(1);
			response.Email.Should().Be("A");
			response.Facebook.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Phone.Should().Be("A");
			response.ProvinceId.Should().Be(1);
			response.Website.Should().Be("A");
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
			ApiVenueClientResponseModel response = await client.VenueGetAsync(default(int));

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
			List<ApiVenueClientResponseModel> response = await client.VenueAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Address1.Should().Be("A");
			response[0].Address2.Should().Be("A");
			response[0].AdminId.Should().Be(1);
			response[0].Email.Should().Be("A");
			response[0].Facebook.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].ProvinceId.Should().Be(1);
			response[0].Website.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByAdminIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVenueClientResponseModel> response = await client.ByVenueByAdminId(1);

			response.Should().NotBeEmpty();
			response[0].Address1.Should().Be("A");
			response[0].Address2.Should().Be("A");
			response[0].AdminId.Should().Be(1);
			response[0].Email.Should().Be("A");
			response[0].Facebook.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].ProvinceId.Should().Be(1);
			response[0].Website.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByAdminIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVenueClientResponseModel> response = await client.ByVenueByAdminId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByProvinceIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVenueClientResponseModel> response = await client.ByVenueByProvinceId(1);

			response.Should().NotBeEmpty();
			response[0].Address1.Should().Be("A");
			response[0].Address2.Should().Be("A");
			response[0].AdminId.Should().Be(1);
			response[0].Email.Should().Be("A");
			response[0].Facebook.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Phone.Should().Be("A");
			response[0].ProvinceId.Should().Be(1);
			response[0].Website.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByProvinceIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVenueClientResponseModel> response = await client.ByVenueByProvinceId(default(int));

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
				var result = await client.VenueAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>c82b72e40c8a5a1b73026b9de9a56623</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/