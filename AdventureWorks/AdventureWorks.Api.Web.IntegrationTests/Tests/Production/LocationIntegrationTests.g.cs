using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Location")]
	[Trait("Area", "Integration")]
	public partial class LocationIntegrationTests
	{
		public LocationIntegrationTests()
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

			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiLocationClientRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiLocationClientRequestModel();
			model2.SetProperties(3, 3m, DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiLocationClientRequestModel>() {model, model2};
			CreateResponse<List<ApiLocationClientResponseModel>> result = await client.LocationBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Location>().ToList()[1].Availability.Should().Be(2);
			context.Set<Location>().ToList()[1].CostRate.Should().Be(2m);
			context.Set<Location>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Location>().ToList()[1].Name.Should().Be("B");

			context.Set<Location>().ToList()[2].Availability.Should().Be(3);
			context.Set<Location>().ToList()[2].CostRate.Should().Be(3m);
			context.Set<Location>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Location>().ToList()[2].Name.Should().Be("C");
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiLocationClientRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiLocationClientResponseModel> result = await client.LocationCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Location>().ToList()[1].Availability.Should().Be(2);
			context.Set<Location>().ToList()[1].CostRate.Should().Be(2m);
			context.Set<Location>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Location>().ToList()[1].Name.Should().Be("B");

			result.Record.Availability.Should().Be(2);
			result.Record.CostRate.Should().Be(2m);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiLocationServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ILocationService service = testServer.Host.Services.GetService(typeof(ILocationService)) as ILocationService;
			ApiLocationServerResponseModel model = await service.Get((short)1);

			ApiLocationClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiLocationClientResponseModel> updateResponse = await client.LocationUpdateAsync(model.LocationID, request);

			context.Entry(context.Set<Location>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.LocationID.Should().Be((short)1);
			context.Set<Location>().ToList()[0].Availability.Should().Be(2);
			context.Set<Location>().ToList()[0].CostRate.Should().Be(2m);
			context.Set<Location>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Location>().ToList()[0].Name.Should().Be("B");

			updateResponse.Record.LocationID.Should().Be((short)1);
			updateResponse.Record.Availability.Should().Be(2);
			updateResponse.Record.CostRate.Should().Be(2m);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ILocationService service = testServer.Host.Services.GetService(typeof(ILocationService)) as ILocationService;
			var model = new ApiLocationServerRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiLocationServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.LocationDeleteAsync((short)2);

			deleteResult.Success.Should().BeTrue();
			ApiLocationServerResponseModel verifyResponse = await service.Get((short)2);

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiLocationClientResponseModel response = await client.LocationGetAsync((short)1);

			response.Should().NotBeNull();
			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiLocationClientResponseModel response = await client.LocationGetAsync(default(short));

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiLocationClientResponseModel> response = await client.LocationAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Availability.Should().Be(1);
			response[0].CostRate.Should().Be(1m);
			response[0].LocationID.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByNameFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiLocationClientResponseModel response = await client.ByLocationByName("A");

			response.Should().NotBeNull();

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByNameNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiLocationClientResponseModel response = await client.ByLocationByName("test_value");

			response.Should().BeNull();
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
				var result = await client.LocationAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>caf134d8016e36f679de4f52708caa7c</Hash>
</Codenesium>*/