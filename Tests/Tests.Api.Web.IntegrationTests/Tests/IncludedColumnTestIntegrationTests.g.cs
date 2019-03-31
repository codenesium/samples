using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Integration")]
	public partial class IncludedColumnTestIntegrationTests
	{
		public IncludedColumnTestIntegrationTests()
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

			var model = new ApiIncludedColumnTestClientRequestModel();
			model.SetProperties("B", "B");
			var model2 = new ApiIncludedColumnTestClientRequestModel();
			model2.SetProperties("C", "C");
			var request = new List<ApiIncludedColumnTestClientRequestModel>() {model, model2};
			CreateResponse<List<ApiIncludedColumnTestClientResponseModel>> result = await client.IncludedColumnTestBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<IncludedColumnTest>().ToList()[1].Name.Should().Be("B");
			context.Set<IncludedColumnTest>().ToList()[1].Name2.Should().Be("B");

			context.Set<IncludedColumnTest>().ToList()[2].Name.Should().Be("C");
			context.Set<IncludedColumnTest>().ToList()[2].Name2.Should().Be("C");
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

			var model = new ApiIncludedColumnTestClientRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiIncludedColumnTestClientResponseModel> result = await client.IncludedColumnTestCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<IncludedColumnTest>().ToList()[1].Name.Should().Be("B");
			context.Set<IncludedColumnTest>().ToList()[1].Name2.Should().Be("B");

			result.Record.Name.Should().Be("B");
			result.Record.Name2.Should().Be("B");
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
			var mapper = new ApiIncludedColumnTestServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IIncludedColumnTestService service = testServer.Host.Services.GetService(typeof(IIncludedColumnTestService)) as IIncludedColumnTestService;
			ApiIncludedColumnTestServerResponseModel model = await service.Get(1);

			ApiIncludedColumnTestClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B");

			UpdateResponse<ApiIncludedColumnTestClientResponseModel> updateResponse = await client.IncludedColumnTestUpdateAsync(model.Id, request);

			context.Entry(context.Set<IncludedColumnTest>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<IncludedColumnTest>().ToList()[0].Name.Should().Be("B");
			context.Set<IncludedColumnTest>().ToList()[0].Name2.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Name2.Should().Be("B");
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

			IIncludedColumnTestService service = testServer.Host.Services.GetService(typeof(IIncludedColumnTestService)) as IIncludedColumnTestService;
			var model = new ApiIncludedColumnTestServerRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiIncludedColumnTestServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.IncludedColumnTestDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiIncludedColumnTestServerResponseModel verifyResponse = await service.Get(2);

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

			ApiIncludedColumnTestClientResponseModel response = await client.IncludedColumnTestGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
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
			ApiIncludedColumnTestClientResponseModel response = await client.IncludedColumnTestGetAsync(default(int));

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
			List<ApiIncludedColumnTestClientResponseModel> response = await client.IncludedColumnTestAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Name2.Should().Be("A");
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
				var result = await client.IncludedColumnTestAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>07a870fecc8fcb4f2c7f63fcc20f3cc2</Hash>
</Codenesium>*/