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
	[Trait("Table", "PersonRef")]
	[Trait("Area", "Integration")]
	public partial class PersonRefIntegrationTests
	{
		public PersonRefIntegrationTests()
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

			var model = new ApiPersonRefClientRequestModel();
			model.SetProperties(2, 2);
			var model2 = new ApiPersonRefClientRequestModel();
			model2.SetProperties(3, 3);
			var request = new List<ApiPersonRefClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPersonRefClientResponseModel>> result = await client.PersonRefBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PersonRef>().ToList()[1].PersonAId.Should().Be(2);
			context.Set<PersonRef>().ToList()[1].PersonBId.Should().Be(2);

			context.Set<PersonRef>().ToList()[2].PersonAId.Should().Be(3);
			context.Set<PersonRef>().ToList()[2].PersonBId.Should().Be(3);
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

			var model = new ApiPersonRefClientRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiPersonRefClientResponseModel> result = await client.PersonRefCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PersonRef>().ToList()[1].PersonAId.Should().Be(2);
			context.Set<PersonRef>().ToList()[1].PersonBId.Should().Be(2);

			result.Record.PersonAId.Should().Be(2);
			result.Record.PersonBId.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiPersonRefServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPersonRefService service = testServer.Host.Services.GetService(typeof(IPersonRefService)) as IPersonRefService;
			ApiPersonRefServerResponseModel model = await service.Get(1);

			ApiPersonRefClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 2);

			UpdateResponse<ApiPersonRefClientResponseModel> updateResponse = await client.PersonRefUpdateAsync(model.Id, request);

			context.Entry(context.Set<PersonRef>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PersonRef>().ToList()[0].PersonAId.Should().Be(2);
			context.Set<PersonRef>().ToList()[0].PersonBId.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.PersonAId.Should().Be(2);
			updateResponse.Record.PersonBId.Should().Be(2);
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

			IPersonRefService service = testServer.Host.Services.GetService(typeof(IPersonRefService)) as IPersonRefService;
			var model = new ApiPersonRefServerRequestModel();
			model.SetProperties(2, 2);
			CreateResponse<ApiPersonRefServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PersonRefDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPersonRefServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPersonRefClientResponseModel response = await client.PersonRefGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPersonRefClientResponseModel response = await client.PersonRefGetAsync(default(int));

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

			List<ApiPersonRefClientResponseModel> response = await client.PersonRefAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].PersonAId.Should().Be(1);
			response[0].PersonBId.Should().Be(1);
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
				var result = await client.PersonRefAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>5424e34f43b67976880978579ed63108</Hash>
</Codenesium>*/