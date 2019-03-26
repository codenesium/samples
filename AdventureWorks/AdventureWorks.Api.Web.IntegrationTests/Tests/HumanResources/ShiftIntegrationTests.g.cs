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
	[Trait("Table", "Shift")]
	[Trait("Area", "Integration")]
	public partial class ShiftIntegrationTests
	{
		public ShiftIntegrationTests()
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

			var model = new ApiShiftClientRequestModel();
			model.SetProperties(TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			var model2 = new ApiShiftClientRequestModel();
			model2.SetProperties(TimeSpan.Parse("03:00:00"), DateTime.Parse("1/1/1989 12:00:00 AM"), "C", TimeSpan.Parse("03:00:00"));
			var request = new List<ApiShiftClientRequestModel>() {model, model2};
			CreateResponse<List<ApiShiftClientResponseModel>> result = await client.ShiftBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Shift>().ToList()[1].EndTime.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Shift>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Shift>().ToList()[1].Name.Should().Be("B");
			context.Set<Shift>().ToList()[1].StartTime.Should().Be(TimeSpan.Parse("02:00:00"));

			context.Set<Shift>().ToList()[2].EndTime.Should().Be(TimeSpan.Parse("03:00:00"));
			context.Set<Shift>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Shift>().ToList()[2].Name.Should().Be("C");
			context.Set<Shift>().ToList()[2].StartTime.Should().Be(TimeSpan.Parse("03:00:00"));
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

			var model = new ApiShiftClientRequestModel();
			model.SetProperties(TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiShiftClientResponseModel> result = await client.ShiftCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Shift>().ToList()[1].EndTime.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Shift>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Shift>().ToList()[1].Name.Should().Be("B");
			context.Set<Shift>().ToList()[1].StartTime.Should().Be(TimeSpan.Parse("02:00:00"));

			result.Record.EndTime.Should().Be(TimeSpan.Parse("02:00:00"));
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Name.Should().Be("B");
			result.Record.StartTime.Should().Be(TimeSpan.Parse("02:00:00"));
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
			var mapper = new ApiShiftServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IShiftService service = testServer.Host.Services.GetService(typeof(IShiftService)) as IShiftService;
			ApiShiftServerResponseModel model = await service.Get(1);

			ApiShiftClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));

			UpdateResponse<ApiShiftClientResponseModel> updateResponse = await client.ShiftUpdateAsync(model.ShiftID, request);

			context.Entry(context.Set<Shift>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ShiftID.Should().Be(1);
			context.Set<Shift>().ToList()[0].EndTime.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Shift>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Shift>().ToList()[0].Name.Should().Be("B");
			context.Set<Shift>().ToList()[0].StartTime.Should().Be(TimeSpan.Parse("02:00:00"));

			updateResponse.Record.ShiftID.Should().Be(1);
			updateResponse.Record.EndTime.Should().Be(TimeSpan.Parse("02:00:00"));
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.StartTime.Should().Be(TimeSpan.Parse("02:00:00"));
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

			IShiftService service = testServer.Host.Services.GetService(typeof(IShiftService)) as IShiftService;
			var model = new ApiShiftServerRequestModel();
			model.SetProperties(TimeSpan.Parse("02:00:00"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiShiftServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ShiftDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiShiftServerResponseModel verifyResponse = await service.Get(2);

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

			ApiShiftClientResponseModel response = await client.ShiftGetAsync(1);

			response.Should().NotBeNull();
			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ShiftID.Should().Be(1);
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
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
			ApiShiftClientResponseModel response = await client.ShiftGetAsync(default(int));

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
			List<ApiShiftClientResponseModel> response = await client.ShiftAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Name.Should().Be("A");
			response[0].ShiftID.Should().Be(1);
			response[0].StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
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
			ApiShiftClientResponseModel response = await client.ByShiftByName("A");

			response.Should().NotBeNull();

			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ShiftID.Should().Be(1);
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
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
			ApiShiftClientResponseModel response = await client.ByShiftByName("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByStartTimeEndTimeFound()
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
			ApiShiftClientResponseModel response = await client.ByShiftByStartTimeEndTime(TimeSpan.Parse("01:00:00"), TimeSpan.Parse("01:00:00"));

			response.Should().NotBeNull();

			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ShiftID.Should().Be(1);
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public virtual async void TestByStartTimeEndTimeNotFound()
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
			ApiShiftClientResponseModel response = await client.ByShiftByStartTimeEndTime(default(TimeSpan), default(TimeSpan));

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
				var result = await client.ShiftAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>f046860c8b4e1476083f5b474e5b47d4</Hash>
</Codenesium>*/