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
	[Trait("Table", "Vendor")]
	[Trait("Area", "Integration")]
	public partial class VendorIntegrationTests
	{
		public VendorIntegrationTests()
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

			var model = new ApiVendorClientRequestModel();
			model.SetProperties("B", true, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			var model2 = new ApiVendorClientRequestModel();
			model2.SetProperties("C", true, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", true, "C");
			var request = new List<ApiVendorClientRequestModel>() {model, model2};
			CreateResponse<List<ApiVendorClientResponseModel>> result = await client.VendorBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Vendor>().ToList()[1].AccountNumber.Should().Be("B");
			context.Set<Vendor>().ToList()[1].ActiveFlag.Should().Be(true);
			context.Set<Vendor>().ToList()[1].CreditRating.Should().Be(2);
			context.Set<Vendor>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Vendor>().ToList()[1].Name.Should().Be("B");
			context.Set<Vendor>().ToList()[1].PreferredVendorStatu.Should().Be(true);
			context.Set<Vendor>().ToList()[1].PurchasingWebServiceURL.Should().Be("B");

			context.Set<Vendor>().ToList()[2].AccountNumber.Should().Be("C");
			context.Set<Vendor>().ToList()[2].ActiveFlag.Should().Be(true);
			context.Set<Vendor>().ToList()[2].CreditRating.Should().Be(3);
			context.Set<Vendor>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Vendor>().ToList()[2].Name.Should().Be("C");
			context.Set<Vendor>().ToList()[2].PreferredVendorStatu.Should().Be(true);
			context.Set<Vendor>().ToList()[2].PurchasingWebServiceURL.Should().Be("C");
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

			var model = new ApiVendorClientRequestModel();
			model.SetProperties("B", true, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			CreateResponse<ApiVendorClientResponseModel> result = await client.VendorCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Vendor>().ToList()[1].AccountNumber.Should().Be("B");
			context.Set<Vendor>().ToList()[1].ActiveFlag.Should().Be(true);
			context.Set<Vendor>().ToList()[1].CreditRating.Should().Be(2);
			context.Set<Vendor>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Vendor>().ToList()[1].Name.Should().Be("B");
			context.Set<Vendor>().ToList()[1].PreferredVendorStatu.Should().Be(true);
			context.Set<Vendor>().ToList()[1].PurchasingWebServiceURL.Should().Be("B");

			result.Record.AccountNumber.Should().Be("B");
			result.Record.ActiveFlag.Should().Be(true);
			result.Record.CreditRating.Should().Be(2);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Name.Should().Be("B");
			result.Record.PreferredVendorStatu.Should().Be(true);
			result.Record.PurchasingWebServiceURL.Should().Be("B");
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
			var mapper = new ApiVendorServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IVendorService service = testServer.Host.Services.GetService(typeof(IVendorService)) as IVendorService;
			ApiVendorServerResponseModel model = await service.Get(1);

			ApiVendorClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", true, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");

			UpdateResponse<ApiVendorClientResponseModel> updateResponse = await client.VendorUpdateAsync(model.BusinessEntityID, request);

			context.Entry(context.Set<Vendor>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.BusinessEntityID.Should().Be(1);
			context.Set<Vendor>().ToList()[0].AccountNumber.Should().Be("B");
			context.Set<Vendor>().ToList()[0].ActiveFlag.Should().Be(true);
			context.Set<Vendor>().ToList()[0].CreditRating.Should().Be(2);
			context.Set<Vendor>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Vendor>().ToList()[0].Name.Should().Be("B");
			context.Set<Vendor>().ToList()[0].PreferredVendorStatu.Should().Be(true);
			context.Set<Vendor>().ToList()[0].PurchasingWebServiceURL.Should().Be("B");

			updateResponse.Record.BusinessEntityID.Should().Be(1);
			updateResponse.Record.AccountNumber.Should().Be("B");
			updateResponse.Record.ActiveFlag.Should().Be(true);
			updateResponse.Record.CreditRating.Should().Be(2);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.PreferredVendorStatu.Should().Be(true);
			updateResponse.Record.PurchasingWebServiceURL.Should().Be("B");
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

			IVendorService service = testServer.Host.Services.GetService(typeof(IVendorService)) as IVendorService;
			var model = new ApiVendorServerRequestModel();
			model.SetProperties("B", true, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			CreateResponse<ApiVendorServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.VendorDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiVendorServerResponseModel verifyResponse = await service.Get(2);

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

			ApiVendorClientResponseModel response = await client.VendorGetAsync(1);

			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.ActiveFlag.Should().Be(true);
			response.BusinessEntityID.Should().Be(1);
			response.CreditRating.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PreferredVendorStatu.Should().Be(true);
			response.PurchasingWebServiceURL.Should().Be("A");
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
			ApiVendorClientResponseModel response = await client.VendorGetAsync(default(int));

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
			List<ApiVendorClientResponseModel> response = await client.VendorAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AccountNumber.Should().Be("A");
			response[0].ActiveFlag.Should().Be(true);
			response[0].BusinessEntityID.Should().Be(1);
			response[0].CreditRating.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Name.Should().Be("A");
			response[0].PreferredVendorStatu.Should().Be(true);
			response[0].PurchasingWebServiceURL.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByAccountNumberFound()
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
			ApiVendorClientResponseModel response = await client.ByVendorByAccountNumber("A");

			response.Should().NotBeNull();

			response.AccountNumber.Should().Be("A");
			response.ActiveFlag.Should().Be(true);
			response.BusinessEntityID.Should().Be(1);
			response.CreditRating.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PreferredVendorStatu.Should().Be(true);
			response.PurchasingWebServiceURL.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByAccountNumberNotFound()
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
			ApiVendorClientResponseModel response = await client.ByVendorByAccountNumber("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeyPurchaseOrderHeadersByVendorIDFound()
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
			List<ApiPurchaseOrderHeaderClientResponseModel> response = await client.PurchaseOrderHeadersByVendorID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPurchaseOrderHeadersByVendorIDNotFound()
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
			List<ApiPurchaseOrderHeaderClientResponseModel> response = await client.PurchaseOrderHeadersByVendorID(default(int));

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
				var result = await client.VendorAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>0ca5b1c67447cd7547fa461084fc9f97</Hash>
</Codenesium>*/