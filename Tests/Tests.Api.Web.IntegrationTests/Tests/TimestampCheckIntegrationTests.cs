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
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "Integration")]
	public partial class TimestampCheckIntegrationTests
	{
		public TimestampCheckIntegrationTests()
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

			var model = new ApiTimestampCheckClientRequestModel();
			model.SetProperties("B", BitConverter.GetBytes(2));
			var model2 = new ApiTimestampCheckClientRequestModel();
			model2.SetProperties("C", BitConverter.GetBytes(3));
			var request = new List<ApiTimestampCheckClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTimestampCheckClientResponseModel>> result = await client.TimestampCheckBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<TimestampCheck>().ToList()[1].Name.Should().Be("B");
			context.Set<TimestampCheck>().ToList()[1].Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));

			context.Set<TimestampCheck>().ToList()[2].Name.Should().Be("C");
			context.Set<TimestampCheck>().ToList()[2].Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(3));
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

			var model = new ApiTimestampCheckClientRequestModel();
			model.SetProperties("B", BitConverter.GetBytes(2));
			CreateResponse<ApiTimestampCheckClientResponseModel> result = await client.TimestampCheckCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<TimestampCheck>().ToList()[1].Name.Should().Be("B");
			context.Set<TimestampCheck>().ToList()[1].Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));

			result.Record.Name.Should().Be("B");
			result.Record.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));
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
			var mapper = new ApiTimestampCheckServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITimestampCheckService service = testServer.Host.Services.GetService(typeof(ITimestampCheckService)) as ITimestampCheckService;
			ApiTimestampCheckServerResponseModel model = await service.Get(1);

			ApiTimestampCheckClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", BitConverter.GetBytes(2));

			UpdateResponse<ApiTimestampCheckClientResponseModel> updateResponse = await client.TimestampCheckUpdateAsync(model.Id, request);

			context.Entry(context.Set<TimestampCheck>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<TimestampCheck>().ToList()[0].Name.Should().Be("B");
			context.Set<TimestampCheck>().ToList()[0].Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(2));
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

			ITimestampCheckService service = testServer.Host.Services.GetService(typeof(ITimestampCheckService)) as ITimestampCheckService;
			var model = new ApiTimestampCheckServerRequestModel();
			model.SetProperties("B", BitConverter.GetBytes(2));
			CreateResponse<ApiTimestampCheckServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TimestampCheckDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTimestampCheckServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTimestampCheckClientResponseModel response = await client.TimestampCheckGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
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
			ApiTimestampCheckClientResponseModel response = await client.TimestampCheckGetAsync(default(int));

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
			List<ApiTimestampCheckClientResponseModel> response = await client.TimestampCheckAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
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
				var result = await client.TimestampCheckAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>c72d0ac3a6869c0df22e7d5c1cb348f0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/