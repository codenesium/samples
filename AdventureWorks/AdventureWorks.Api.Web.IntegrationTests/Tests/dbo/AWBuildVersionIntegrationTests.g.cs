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
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "Integration")]
	public partial class AWBuildVersionIntegrationTests
	{
		public AWBuildVersionIntegrationTests()
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

			var model = new ApiAWBuildVersionClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			var model2 = new ApiAWBuildVersionClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"));
			var request = new List<ApiAWBuildVersionClientRequestModel>() {model, model2};
			CreateResponse<List<ApiAWBuildVersionClientResponseModel>> result = await client.AWBuildVersionBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<AWBuildVersion>().ToList()[1].Database_Version.Should().Be("B");
			context.Set<AWBuildVersion>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AWBuildVersion>().ToList()[1].VersionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			context.Set<AWBuildVersion>().ToList()[2].Database_Version.Should().Be("C");
			context.Set<AWBuildVersion>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<AWBuildVersion>().ToList()[2].VersionDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
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

			var model = new ApiAWBuildVersionClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiAWBuildVersionClientResponseModel> result = await client.AWBuildVersionCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<AWBuildVersion>().ToList()[1].Database_Version.Should().Be("B");
			context.Set<AWBuildVersion>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AWBuildVersion>().ToList()[1].VersionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			result.Record.Database_Version.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.VersionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiAWBuildVersionServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IAWBuildVersionService service = testServer.Host.Services.GetService(typeof(IAWBuildVersionService)) as IAWBuildVersionService;
			ApiAWBuildVersionServerResponseModel model = await service.Get(1);

			ApiAWBuildVersionClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));

			UpdateResponse<ApiAWBuildVersionClientResponseModel> updateResponse = await client.AWBuildVersionUpdateAsync(model.SystemInformationID, request);

			context.Entry(context.Set<AWBuildVersion>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.SystemInformationID.Should().Be(1);
			context.Set<AWBuildVersion>().ToList()[0].Database_Version.Should().Be("B");
			context.Set<AWBuildVersion>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<AWBuildVersion>().ToList()[0].VersionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			updateResponse.Record.SystemInformationID.Should().Be(1);
			updateResponse.Record.Database_Version.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.VersionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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

			IAWBuildVersionService service = testServer.Host.Services.GetService(typeof(IAWBuildVersionService)) as IAWBuildVersionService;
			var model = new ApiAWBuildVersionServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiAWBuildVersionServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.AWBuildVersionDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiAWBuildVersionServerResponseModel verifyResponse = await service.Get(2);

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

			ApiAWBuildVersionClientResponseModel response = await client.AWBuildVersionGetAsync(1);

			response.Should().NotBeNull();
			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SystemInformationID.Should().Be(1);
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiAWBuildVersionClientResponseModel response = await client.AWBuildVersionGetAsync(default(int));

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

			List<ApiAWBuildVersionClientResponseModel> response = await client.AWBuildVersionAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Database_Version.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].SystemInformationID.Should().Be(1);
			response[0].VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
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
				var result = await client.AWBuildVersionAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>51f7d7cbc42e5fad0343e6b49e30f89d</Hash>
</Codenesium>*/