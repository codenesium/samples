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
	[Trait("Table", "Rate")]
	[Trait("Area", "Integration")]
	public partial class RateIntegrationTests
	{
		public RateIntegrationTests()
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

			var model = new ApiRateClientRequestModel();
			model.SetProperties(2m, 2, 2);
			var model2 = new ApiRateClientRequestModel();
			model2.SetProperties(3m, 3, 3);
			var request = new List<ApiRateClientRequestModel>() {model, model2};
			CreateResponse<List<ApiRateClientResponseModel>> result = await client.RateBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Rate>().ToList()[1].AmountPerMinute.Should().Be(2m);
			context.Set<Rate>().ToList()[1].TeacherId.Should().Be(2);
			context.Set<Rate>().ToList()[1].TeacherSkillId.Should().Be(2);

			context.Set<Rate>().ToList()[2].AmountPerMinute.Should().Be(3m);
			context.Set<Rate>().ToList()[2].TeacherId.Should().Be(3);
			context.Set<Rate>().ToList()[2].TeacherSkillId.Should().Be(3);
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

			var model = new ApiRateClientRequestModel();
			model.SetProperties(2m, 2, 2);
			CreateResponse<ApiRateClientResponseModel> result = await client.RateCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Rate>().ToList()[1].AmountPerMinute.Should().Be(2m);
			context.Set<Rate>().ToList()[1].TeacherId.Should().Be(2);
			context.Set<Rate>().ToList()[1].TeacherSkillId.Should().Be(2);

			result.Record.AmountPerMinute.Should().Be(2m);
			result.Record.TeacherId.Should().Be(2);
			result.Record.TeacherSkillId.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiRateServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IRateService service = testServer.Host.Services.GetService(typeof(IRateService)) as IRateService;
			ApiRateServerResponseModel model = await service.Get(1);

			ApiRateClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, 2, 2);

			UpdateResponse<ApiRateClientResponseModel> updateResponse = await client.RateUpdateAsync(model.Id, request);

			context.Entry(context.Set<Rate>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Rate>().ToList()[0].AmountPerMinute.Should().Be(2m);
			context.Set<Rate>().ToList()[0].TeacherId.Should().Be(2);
			context.Set<Rate>().ToList()[0].TeacherSkillId.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.AmountPerMinute.Should().Be(2m);
			updateResponse.Record.TeacherId.Should().Be(2);
			updateResponse.Record.TeacherSkillId.Should().Be(2);
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

			IRateService service = testServer.Host.Services.GetService(typeof(IRateService)) as IRateService;
			var model = new ApiRateServerRequestModel();
			model.SetProperties(2m, 2, 2);
			CreateResponse<ApiRateServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.RateDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiRateServerResponseModel verifyResponse = await service.Get(2);

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

			ApiRateClientResponseModel response = await client.RateGetAsync(1);

			response.Should().NotBeNull();
			response.AmountPerMinute.Should().Be(1m);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiRateClientResponseModel response = await client.RateGetAsync(default(int));

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

			List<ApiRateClientResponseModel> response = await client.RateAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AmountPerMinute.Should().Be(1m);
			response[0].Id.Should().Be(1);
			response[0].TeacherId.Should().Be(1);
			response[0].TeacherSkillId.Should().Be(1);
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
				var result = await client.RateAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>cbeb83ff4a36573e3552d2058f6ba6d3</Hash>
</Codenesium>*/