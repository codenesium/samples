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
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "Integration")]
	public partial class CurrencyRateIntegrationTests
	{
		public CurrencyRateIntegrationTests()
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

			var model = new ApiCurrencyRateClientRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			var model2 = new ApiCurrencyRateClientRequestModel();
			model2.SetProperties(3m, DateTime.Parse("1/1/1989 12:00:00 AM"), 3m, "A", DateTime.Parse("1/1/1989 12:00:00 AM"), "A");
			var request = new List<ApiCurrencyRateClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCurrencyRateClientResponseModel>> result = await client.CurrencyRateBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<CurrencyRate>().ToList()[1].AverageRate.Should().Be(2m);
			context.Set<CurrencyRate>().ToList()[1].CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[1].EndOfDayRate.Should().Be(2m);
			context.Set<CurrencyRate>().ToList()[1].FromCurrencyCode.Should().Be("A");
			context.Set<CurrencyRate>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[1].ToCurrencyCode.Should().Be("A");

			context.Set<CurrencyRate>().ToList()[2].AverageRate.Should().Be(3m);
			context.Set<CurrencyRate>().ToList()[2].CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[2].EndOfDayRate.Should().Be(3m);
			context.Set<CurrencyRate>().ToList()[2].FromCurrencyCode.Should().Be("A");
			context.Set<CurrencyRate>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[2].ToCurrencyCode.Should().Be("A");
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

			var model = new ApiCurrencyRateClientRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			CreateResponse<ApiCurrencyRateClientResponseModel> result = await client.CurrencyRateCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<CurrencyRate>().ToList()[1].AverageRate.Should().Be(2m);
			context.Set<CurrencyRate>().ToList()[1].CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[1].EndOfDayRate.Should().Be(2m);
			context.Set<CurrencyRate>().ToList()[1].FromCurrencyCode.Should().Be("A");
			context.Set<CurrencyRate>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[1].ToCurrencyCode.Should().Be("A");

			result.Record.AverageRate.Should().Be(2m);
			result.Record.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.EndOfDayRate.Should().Be(2m);
			result.Record.FromCurrencyCode.Should().Be("A");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiCurrencyRateServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICurrencyRateService service = testServer.Host.Services.GetService(typeof(ICurrencyRateService)) as ICurrencyRateService;
			ApiCurrencyRateServerResponseModel model = await service.Get(1);

			ApiCurrencyRateClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");

			UpdateResponse<ApiCurrencyRateClientResponseModel> updateResponse = await client.CurrencyRateUpdateAsync(model.CurrencyRateID, request);

			context.Entry(context.Set<CurrencyRate>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.CurrencyRateID.Should().Be(1);
			context.Set<CurrencyRate>().ToList()[0].AverageRate.Should().Be(2m);
			context.Set<CurrencyRate>().ToList()[0].CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[0].EndOfDayRate.Should().Be(2m);
			context.Set<CurrencyRate>().ToList()[0].FromCurrencyCode.Should().Be("A");
			context.Set<CurrencyRate>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<CurrencyRate>().ToList()[0].ToCurrencyCode.Should().Be("A");

			updateResponse.Record.CurrencyRateID.Should().Be(1);
			updateResponse.Record.AverageRate.Should().Be(2m);
			updateResponse.Record.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.EndOfDayRate.Should().Be(2m);
			updateResponse.Record.FromCurrencyCode.Should().Be("A");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ToCurrencyCode.Should().Be("A");
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

			ICurrencyRateService service = testServer.Host.Services.GetService(typeof(ICurrencyRateService)) as ICurrencyRateService;
			var model = new ApiCurrencyRateServerRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, "A", DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			CreateResponse<ApiCurrencyRateServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CurrencyRateDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCurrencyRateServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCurrencyRateClientResponseModel response = await client.CurrencyRateGetAsync(1);

			response.Should().NotBeNull();
			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CurrencyRateID.Should().Be(1);
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCurrencyRateClientResponseModel response = await client.CurrencyRateGetAsync(default(int));

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

			List<ApiCurrencyRateClientResponseModel> response = await client.CurrencyRateAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AverageRate.Should().Be(1m);
			response[0].CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CurrencyRateID.Should().Be(1);
			response[0].EndOfDayRate.Should().Be(1m);
			response[0].FromCurrencyCode.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByCurrencyRateDateFromCurrencyCodeToCurrencyCodeFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCurrencyRateClientResponseModel response = await client.ByCurrencyRateByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			response.Should().NotBeNull();

			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CurrencyRateID.Should().Be(1);
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByCurrencyRateDateFromCurrencyCodeToCurrencyCodeNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCurrencyRateClientResponseModel response = await client.ByCurrencyRateByCurrencyRateDateFromCurrencyCodeToCurrencyCode(default(DateTime), "test_value", "test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByCurrencyRateIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByCurrencyRateID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByCurrencyRateIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByCurrencyRateID(default(int));

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
				var result = await client.CurrencyRateAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>b109cca7bdb4b4c611ca42e204d49576</Hash>
</Codenesium>*/