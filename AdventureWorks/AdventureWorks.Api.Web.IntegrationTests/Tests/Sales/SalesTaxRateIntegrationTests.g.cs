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
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "Integration")]
	public partial class SalesTaxRateIntegrationTests
	{
		public SalesTaxRateIntegrationTests()
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

			var model = new ApiSalesTaxRateClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			var model2 = new ApiSalesTaxRateClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 3, 3m, 3);
			var request = new List<ApiSalesTaxRateClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSalesTaxRateClientResponseModel>> result = await client.SalesTaxRateBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SalesTaxRate>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesTaxRate>().ToList()[1].Name.Should().Be("B");
			context.Set<SalesTaxRate>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesTaxRate>().ToList()[1].StateProvinceID.Should().Be(2);
			context.Set<SalesTaxRate>().ToList()[1].TaxRate.Should().Be(2m);
			context.Set<SalesTaxRate>().ToList()[1].TaxType.Should().Be(2);

			context.Set<SalesTaxRate>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SalesTaxRate>().ToList()[2].Name.Should().Be("C");
			context.Set<SalesTaxRate>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<SalesTaxRate>().ToList()[2].StateProvinceID.Should().Be(3);
			context.Set<SalesTaxRate>().ToList()[2].TaxRate.Should().Be(3m);
			context.Set<SalesTaxRate>().ToList()[2].TaxType.Should().Be(3);
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

			var model = new ApiSalesTaxRateClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			CreateResponse<ApiSalesTaxRateClientResponseModel> result = await client.SalesTaxRateCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SalesTaxRate>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesTaxRate>().ToList()[1].Name.Should().Be("B");
			context.Set<SalesTaxRate>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesTaxRate>().ToList()[1].StateProvinceID.Should().Be(2);
			context.Set<SalesTaxRate>().ToList()[1].TaxRate.Should().Be(2m);
			context.Set<SalesTaxRate>().ToList()[1].TaxType.Should().Be(2);

			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Name.Should().Be("B");
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.StateProvinceID.Should().Be(2);
			result.Record.TaxRate.Should().Be(2m);
			result.Record.TaxType.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiSalesTaxRateServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISalesTaxRateService service = testServer.Host.Services.GetService(typeof(ISalesTaxRateService)) as ISalesTaxRateService;
			ApiSalesTaxRateServerResponseModel model = await service.Get(1);

			ApiSalesTaxRateClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);

			UpdateResponse<ApiSalesTaxRateClientResponseModel> updateResponse = await client.SalesTaxRateUpdateAsync(model.SalesTaxRateID, request);

			context.Entry(context.Set<SalesTaxRate>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.SalesTaxRateID.Should().Be(1);
			context.Set<SalesTaxRate>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesTaxRate>().ToList()[0].Name.Should().Be("B");
			context.Set<SalesTaxRate>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesTaxRate>().ToList()[0].StateProvinceID.Should().Be(2);
			context.Set<SalesTaxRate>().ToList()[0].TaxRate.Should().Be(2m);
			context.Set<SalesTaxRate>().ToList()[0].TaxType.Should().Be(2);

			updateResponse.Record.SalesTaxRateID.Should().Be(1);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.StateProvinceID.Should().Be(2);
			updateResponse.Record.TaxRate.Should().Be(2m);
			updateResponse.Record.TaxType.Should().Be(2);
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

			ISalesTaxRateService service = testServer.Host.Services.GetService(typeof(ISalesTaxRateService)) as ISalesTaxRateService;
			var model = new ApiSalesTaxRateServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			CreateResponse<ApiSalesTaxRateServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SalesTaxRateDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSalesTaxRateServerResponseModel verifyResponse = await service.Get(2);

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

			ApiSalesTaxRateClientResponseModel response = await client.SalesTaxRateGetAsync(1);

			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesTaxRateID.Should().Be(1);
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTaxRateClientResponseModel response = await client.SalesTaxRateGetAsync(default(int));

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

			List<ApiSalesTaxRateClientResponseModel> response = await client.SalesTaxRateAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Name.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SalesTaxRateID.Should().Be(1);
			response[0].StateProvinceID.Should().Be(1);
			response[0].TaxRate.Should().Be(1m);
			response[0].TaxType.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRowguidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTaxRateClientResponseModel response = await client.BySalesTaxRateByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesTaxRateID.Should().Be(1);
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTaxRateClientResponseModel response = await client.BySalesTaxRateByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByStateProvinceIDTaxTypeFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTaxRateClientResponseModel response = await client.BySalesTaxRateByStateProvinceIDTaxType(1, 1);

			response.Should().NotBeNull();

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesTaxRateID.Should().Be(1);
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByStateProvinceIDTaxTypeNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTaxRateClientResponseModel response = await client.BySalesTaxRateByStateProvinceIDTaxType(default(int), default(int));

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
				var result = await client.SalesTaxRateAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>2949bb7068248836b6a1be1cedd51c57</Hash>
</Codenesium>*/