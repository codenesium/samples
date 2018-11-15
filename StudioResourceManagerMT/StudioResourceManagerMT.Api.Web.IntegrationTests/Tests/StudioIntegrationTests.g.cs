using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerMTNS.Api.Client;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Studio")]
	[Trait("Area", "Integration")]
	public partial class StudioIntegrationTests
	{
		public StudioIntegrationTests()
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

			var model = new ApiStudioClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B", "B");
			var model2 = new ApiStudioClientRequestModel();
			model2.SetProperties("C", "C", "C", "C", "C", "C", "C");
			var request = new List<ApiStudioClientRequestModel>() {model, model2};
			CreateResponse<List<ApiStudioClientResponseModel>> result = await client.StudioBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Studio>().ToList()[1].Address1.Should().Be("B");
			context.Set<Studio>().ToList()[1].Address2.Should().Be("B");
			context.Set<Studio>().ToList()[1].City.Should().Be("B");
			context.Set<Studio>().ToList()[1].Name.Should().Be("B");
			context.Set<Studio>().ToList()[1].Province.Should().Be("B");
			context.Set<Studio>().ToList()[1].Website.Should().Be("B");
			context.Set<Studio>().ToList()[1].Zip.Should().Be("B");

			context.Set<Studio>().ToList()[2].Address1.Should().Be("C");
			context.Set<Studio>().ToList()[2].Address2.Should().Be("C");
			context.Set<Studio>().ToList()[2].City.Should().Be("C");
			context.Set<Studio>().ToList()[2].Name.Should().Be("C");
			context.Set<Studio>().ToList()[2].Province.Should().Be("C");
			context.Set<Studio>().ToList()[2].Website.Should().Be("C");
			context.Set<Studio>().ToList()[2].Zip.Should().Be("C");
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

			var model = new ApiStudioClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiStudioClientResponseModel> result = await client.StudioCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Studio>().ToList()[1].Address1.Should().Be("B");
			context.Set<Studio>().ToList()[1].Address2.Should().Be("B");
			context.Set<Studio>().ToList()[1].City.Should().Be("B");
			context.Set<Studio>().ToList()[1].Name.Should().Be("B");
			context.Set<Studio>().ToList()[1].Province.Should().Be("B");
			context.Set<Studio>().ToList()[1].Website.Should().Be("B");
			context.Set<Studio>().ToList()[1].Zip.Should().Be("B");

			result.Record.Address1.Should().Be("B");
			result.Record.Address2.Should().Be("B");
			result.Record.City.Should().Be("B");
			result.Record.Name.Should().Be("B");
			result.Record.Province.Should().Be("B");
			result.Record.Website.Should().Be("B");
			result.Record.Zip.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiStudioServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IStudioService service = testServer.Host.Services.GetService(typeof(IStudioService)) as IStudioService;
			ApiStudioServerResponseModel model = await service.Get(1);

			ApiStudioClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", "B", "B", "B", "B");

			UpdateResponse<ApiStudioClientResponseModel> updateResponse = await client.StudioUpdateAsync(model.Id, request);

			context.Entry(context.Set<Studio>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Studio>().ToList()[0].Address1.Should().Be("B");
			context.Set<Studio>().ToList()[0].Address2.Should().Be("B");
			context.Set<Studio>().ToList()[0].City.Should().Be("B");
			context.Set<Studio>().ToList()[0].Name.Should().Be("B");
			context.Set<Studio>().ToList()[0].Province.Should().Be("B");
			context.Set<Studio>().ToList()[0].Website.Should().Be("B");
			context.Set<Studio>().ToList()[0].Zip.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Address1.Should().Be("B");
			updateResponse.Record.Address2.Should().Be("B");
			updateResponse.Record.City.Should().Be("B");
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Province.Should().Be("B");
			updateResponse.Record.Website.Should().Be("B");
			updateResponse.Record.Zip.Should().Be("B");
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

			IStudioService service = testServer.Host.Services.GetService(typeof(IStudioService)) as IStudioService;
			var model = new ApiStudioServerRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiStudioServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.StudioDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiStudioServerResponseModel verifyResponse = await service.Get(2);

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

			ApiStudioClientResponseModel response = await client.StudioGetAsync(1);

			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiStudioClientResponseModel response = await client.StudioGetAsync(default(int));

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

			List<ApiStudioClientResponseModel> response = await client.StudioAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Address1.Should().Be("A");
			response[0].Address2.Should().Be("A");
			response[0].City.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Province.Should().Be("A");
			response[0].Website.Should().Be("A");
			response[0].Zip.Should().Be("A");
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
				var result = await client.StudioAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>786d48695e41f70d8a2ab1e98ff9a32b</Hash>
</Codenesium>*/