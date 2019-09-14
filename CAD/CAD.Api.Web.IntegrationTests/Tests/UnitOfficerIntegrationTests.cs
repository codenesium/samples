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
	[Trait("Table", "UnitOfficer")]
	[Trait("Area", "Integration")]
	public partial class UnitOfficerIntegrationTests
	{
		public UnitOfficerIntegrationTests()
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

			var model = new ApiUnitOfficerClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiUnitOfficerClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiUnitOfficerClientRequestModel>() {model, model2};
			CreateResponse<List<ApiUnitOfficerClientResponseModel>> result = await client.UnitOfficerBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<UnitOfficer>().ToList()[1].OfficerId.Should().Be(1);
			context.Set<UnitOfficer>().ToList()[1].UnitId.Should().Be(1);

			context.Set<UnitOfficer>().ToList()[2].OfficerId.Should().Be(1);
			context.Set<UnitOfficer>().ToList()[2].UnitId.Should().Be(1);
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

			var model = new ApiUnitOfficerClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiUnitOfficerClientResponseModel> result = await client.UnitOfficerCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<UnitOfficer>().ToList()[1].OfficerId.Should().Be(1);
			context.Set<UnitOfficer>().ToList()[1].UnitId.Should().Be(1);

			result.Record.OfficerId.Should().Be(1);
			result.Record.UnitId.Should().Be(1);
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
			var mapper = new ApiUnitOfficerServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IUnitOfficerService service = testServer.Host.Services.GetService(typeof(IUnitOfficerService)) as IUnitOfficerService;
			ApiUnitOfficerServerResponseModel model = await service.Get(1);

			ApiUnitOfficerClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiUnitOfficerClientResponseModel> updateResponse = await client.UnitOfficerUpdateAsync(model.Id, request);

			context.Entry(context.Set<UnitOfficer>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<UnitOfficer>().ToList()[0].OfficerId.Should().Be(1);
			context.Set<UnitOfficer>().ToList()[0].UnitId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.OfficerId.Should().Be(1);
			updateResponse.Record.UnitId.Should().Be(1);
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

			IUnitOfficerService service = testServer.Host.Services.GetService(typeof(IUnitOfficerService)) as IUnitOfficerService;
			var model = new ApiUnitOfficerServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiUnitOfficerServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.UnitOfficerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiUnitOfficerServerResponseModel verifyResponse = await service.Get(2);

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

			ApiUnitOfficerClientResponseModel response = await client.UnitOfficerGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
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
			ApiUnitOfficerClientResponseModel response = await client.UnitOfficerGetAsync(default(int));

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
			List<ApiUnitOfficerClientResponseModel> response = await client.UnitOfficerAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].OfficerId.Should().Be(1);
			response[0].UnitId.Should().Be(1);
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
				var result = await client.UnitOfficerAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>eaf2a6c899ee042d6f740c414ac21949</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/