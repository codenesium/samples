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
	[Trait("Table", "Product")]
	[Trait("Area", "Integration")]
	public partial class ProductIntegrationTests
	{
		public ProductIntegrationTests()
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

			var model = new ApiProductClientRequestModel();
			model.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			var model2 = new ApiProductClientRequestModel();
			model2.SetProperties("C", 3, DateTime.Parse("1/1/1989 12:00:00 AM"), true, 3m, true, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C", 1, "C", 1, 3, "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 3, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "A", 3m, "C", 3, "A");
			var request = new List<ApiProductClientRequestModel>() {model, model2};
			CreateResponse<List<ApiProductClientResponseModel>> result = await client.ProductBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Product>().ToList()[1].Color.Should().Be("B");
			context.Set<Product>().ToList()[1].DaysToManufacture.Should().Be(2);
			context.Set<Product>().ToList()[1].DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].FinishedGoodsFlag.Should().Be(true);
			context.Set<Product>().ToList()[1].ListPrice.Should().Be(2m);
			context.Set<Product>().ToList()[1].MakeFlag.Should().Be(true);
			context.Set<Product>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].Name.Should().Be("B");
			context.Set<Product>().ToList()[1].ProductLine.Should().Be("B");
			context.Set<Product>().ToList()[1].ProductModelID.Should().Be(1);
			context.Set<Product>().ToList()[1].ProductNumber.Should().Be("B");
			context.Set<Product>().ToList()[1].ProductSubcategoryID.Should().Be(1);
			context.Set<Product>().ToList()[1].ReorderPoint.Should().Be(2);
			context.Set<Product>().ToList()[1].ReservedClass.Should().Be("B");
			context.Set<Product>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Product>().ToList()[1].SafetyStockLevel.Should().Be(2);
			context.Set<Product>().ToList()[1].SellEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].SellStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].Size.Should().Be("B");
			context.Set<Product>().ToList()[1].SizeUnitMeasureCode.Should().Be("A");
			context.Set<Product>().ToList()[1].StandardCost.Should().Be(2m);
			context.Set<Product>().ToList()[1].Style.Should().Be("B");
			context.Set<Product>().ToList()[1].Weight.Should().Be(2);
			context.Set<Product>().ToList()[1].WeightUnitMeasureCode.Should().Be("A");

			context.Set<Product>().ToList()[2].Color.Should().Be("C");
			context.Set<Product>().ToList()[2].DaysToManufacture.Should().Be(3);
			context.Set<Product>().ToList()[2].DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Product>().ToList()[2].FinishedGoodsFlag.Should().Be(true);
			context.Set<Product>().ToList()[2].ListPrice.Should().Be(3m);
			context.Set<Product>().ToList()[2].MakeFlag.Should().Be(true);
			context.Set<Product>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Product>().ToList()[2].Name.Should().Be("C");
			context.Set<Product>().ToList()[2].ProductLine.Should().Be("C");
			context.Set<Product>().ToList()[2].ProductModelID.Should().Be(1);
			context.Set<Product>().ToList()[2].ProductNumber.Should().Be("C");
			context.Set<Product>().ToList()[2].ProductSubcategoryID.Should().Be(1);
			context.Set<Product>().ToList()[2].ReorderPoint.Should().Be(3);
			context.Set<Product>().ToList()[2].ReservedClass.Should().Be("C");
			context.Set<Product>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Product>().ToList()[2].SafetyStockLevel.Should().Be(3);
			context.Set<Product>().ToList()[2].SellEndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Product>().ToList()[2].SellStartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Product>().ToList()[2].Size.Should().Be("C");
			context.Set<Product>().ToList()[2].SizeUnitMeasureCode.Should().Be("A");
			context.Set<Product>().ToList()[2].StandardCost.Should().Be(3m);
			context.Set<Product>().ToList()[2].Style.Should().Be("C");
			context.Set<Product>().ToList()[2].Weight.Should().Be(3);
			context.Set<Product>().ToList()[2].WeightUnitMeasureCode.Should().Be("A");
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

			var model = new ApiProductClientRequestModel();
			model.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			CreateResponse<ApiProductClientResponseModel> result = await client.ProductCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Product>().ToList()[1].Color.Should().Be("B");
			context.Set<Product>().ToList()[1].DaysToManufacture.Should().Be(2);
			context.Set<Product>().ToList()[1].DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].FinishedGoodsFlag.Should().Be(true);
			context.Set<Product>().ToList()[1].ListPrice.Should().Be(2m);
			context.Set<Product>().ToList()[1].MakeFlag.Should().Be(true);
			context.Set<Product>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].Name.Should().Be("B");
			context.Set<Product>().ToList()[1].ProductLine.Should().Be("B");
			context.Set<Product>().ToList()[1].ProductModelID.Should().Be(1);
			context.Set<Product>().ToList()[1].ProductNumber.Should().Be("B");
			context.Set<Product>().ToList()[1].ProductSubcategoryID.Should().Be(1);
			context.Set<Product>().ToList()[1].ReorderPoint.Should().Be(2);
			context.Set<Product>().ToList()[1].ReservedClass.Should().Be("B");
			context.Set<Product>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Product>().ToList()[1].SafetyStockLevel.Should().Be(2);
			context.Set<Product>().ToList()[1].SellEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].SellStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[1].Size.Should().Be("B");
			context.Set<Product>().ToList()[1].SizeUnitMeasureCode.Should().Be("A");
			context.Set<Product>().ToList()[1].StandardCost.Should().Be(2m);
			context.Set<Product>().ToList()[1].Style.Should().Be("B");
			context.Set<Product>().ToList()[1].Weight.Should().Be(2);
			context.Set<Product>().ToList()[1].WeightUnitMeasureCode.Should().Be("A");

			result.Record.Color.Should().Be("B");
			result.Record.DaysToManufacture.Should().Be(2);
			result.Record.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FinishedGoodsFlag.Should().Be(true);
			result.Record.ListPrice.Should().Be(2m);
			result.Record.MakeFlag.Should().Be(true);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Name.Should().Be("B");
			result.Record.ProductLine.Should().Be("B");
			result.Record.ProductModelID.Should().Be(1);
			result.Record.ProductNumber.Should().Be("B");
			result.Record.ProductSubcategoryID.Should().Be(1);
			result.Record.ReorderPoint.Should().Be(2);
			result.Record.ReservedClass.Should().Be("B");
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.SafetyStockLevel.Should().Be(2);
			result.Record.SellEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.SellStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Size.Should().Be("B");
			result.Record.SizeUnitMeasureCode.Should().Be("A");
			result.Record.StandardCost.Should().Be(2m);
			result.Record.Style.Should().Be("B");
			result.Record.Weight.Should().Be(2);
			result.Record.WeightUnitMeasureCode.Should().Be("A");
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
			var mapper = new ApiProductServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IProductService service = testServer.Host.Services.GetService(typeof(IProductService)) as IProductService;
			ApiProductServerResponseModel model = await service.Get(1);

			ApiProductClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");

			UpdateResponse<ApiProductClientResponseModel> updateResponse = await client.ProductUpdateAsync(model.ProductID, request);

			context.Entry(context.Set<Product>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ProductID.Should().Be(1);
			context.Set<Product>().ToList()[0].Color.Should().Be("B");
			context.Set<Product>().ToList()[0].DaysToManufacture.Should().Be(2);
			context.Set<Product>().ToList()[0].DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[0].FinishedGoodsFlag.Should().Be(true);
			context.Set<Product>().ToList()[0].ListPrice.Should().Be(2m);
			context.Set<Product>().ToList()[0].MakeFlag.Should().Be(true);
			context.Set<Product>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[0].Name.Should().Be("B");
			context.Set<Product>().ToList()[0].ProductLine.Should().Be("B");
			context.Set<Product>().ToList()[0].ProductModelID.Should().Be(1);
			context.Set<Product>().ToList()[0].ProductNumber.Should().Be("B");
			context.Set<Product>().ToList()[0].ProductSubcategoryID.Should().Be(1);
			context.Set<Product>().ToList()[0].ReorderPoint.Should().Be(2);
			context.Set<Product>().ToList()[0].ReservedClass.Should().Be("B");
			context.Set<Product>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Product>().ToList()[0].SafetyStockLevel.Should().Be(2);
			context.Set<Product>().ToList()[0].SellEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[0].SellStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Product>().ToList()[0].Size.Should().Be("B");
			context.Set<Product>().ToList()[0].SizeUnitMeasureCode.Should().Be("A");
			context.Set<Product>().ToList()[0].StandardCost.Should().Be(2m);
			context.Set<Product>().ToList()[0].Style.Should().Be("B");
			context.Set<Product>().ToList()[0].Weight.Should().Be(2);
			context.Set<Product>().ToList()[0].WeightUnitMeasureCode.Should().Be("A");

			updateResponse.Record.ProductID.Should().Be(1);
			updateResponse.Record.Color.Should().Be("B");
			updateResponse.Record.DaysToManufacture.Should().Be(2);
			updateResponse.Record.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FinishedGoodsFlag.Should().Be(true);
			updateResponse.Record.ListPrice.Should().Be(2m);
			updateResponse.Record.MakeFlag.Should().Be(true);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.ProductLine.Should().Be("B");
			updateResponse.Record.ProductModelID.Should().Be(1);
			updateResponse.Record.ProductNumber.Should().Be("B");
			updateResponse.Record.ProductSubcategoryID.Should().Be(1);
			updateResponse.Record.ReorderPoint.Should().Be(2);
			updateResponse.Record.ReservedClass.Should().Be("B");
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.SafetyStockLevel.Should().Be(2);
			updateResponse.Record.SellEndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.SellStartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Size.Should().Be("B");
			updateResponse.Record.SizeUnitMeasureCode.Should().Be("A");
			updateResponse.Record.StandardCost.Should().Be(2m);
			updateResponse.Record.Style.Should().Be("B");
			updateResponse.Record.Weight.Should().Be(2);
			updateResponse.Record.WeightUnitMeasureCode.Should().Be("A");
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

			IProductService service = testServer.Host.Services.GetService(typeof(IProductService)) as IProductService;
			var model = new ApiProductServerRequestModel();
			model.SetProperties("B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 1, "B", 1, 2, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "A", 2m, "B", 2, "A");
			CreateResponse<ApiProductServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ProductDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiProductServerResponseModel verifyResponse = await service.Get(2);

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

			ApiProductClientResponseModel response = await client.ProductGetAsync(1);

			response.Should().NotBeNull();
			response.Color.Should().Be("A");
			response.DaysToManufacture.Should().Be(1);
			response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FinishedGoodsFlag.Should().Be(true);
			response.ListPrice.Should().Be(1m);
			response.MakeFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductLine.Should().Be("A");
			response.ProductModelID.Should().Be(1);
			response.ProductNumber.Should().Be("A");
			response.ProductSubcategoryID.Should().Be(1);
			response.ReorderPoint.Should().Be(1);
			response.ReservedClass.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SafetyStockLevel.Should().Be(1);
			response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Size.Should().Be("A");
			response.SizeUnitMeasureCode.Should().Be("A");
			response.StandardCost.Should().Be(1m);
			response.Style.Should().Be("A");
			response.Weight.Should().Be(1);
			response.WeightUnitMeasureCode.Should().Be("A");
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
			ApiProductClientResponseModel response = await client.ProductGetAsync(default(int));

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
			List<ApiProductClientResponseModel> response = await client.ProductAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Color.Should().Be("A");
			response[0].DaysToManufacture.Should().Be(1);
			response[0].DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FinishedGoodsFlag.Should().Be(true);
			response[0].ListPrice.Should().Be(1m);
			response[0].MakeFlag.Should().Be(true);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Name.Should().Be("A");
			response[0].ProductID.Should().Be(1);
			response[0].ProductLine.Should().Be("A");
			response[0].ProductModelID.Should().Be(1);
			response[0].ProductNumber.Should().Be("A");
			response[0].ProductSubcategoryID.Should().Be(1);
			response[0].ReorderPoint.Should().Be(1);
			response[0].ReservedClass.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SafetyStockLevel.Should().Be(1);
			response[0].SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Size.Should().Be("A");
			response[0].SizeUnitMeasureCode.Should().Be("A");
			response[0].StandardCost.Should().Be(1m);
			response[0].Style.Should().Be("A");
			response[0].Weight.Should().Be(1);
			response[0].WeightUnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByNameFound()
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
			ApiProductClientResponseModel response = await client.ByProductByName("A");

			response.Should().NotBeNull();

			response.Color.Should().Be("A");
			response.DaysToManufacture.Should().Be(1);
			response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FinishedGoodsFlag.Should().Be(true);
			response.ListPrice.Should().Be(1m);
			response.MakeFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductLine.Should().Be("A");
			response.ProductModelID.Should().Be(1);
			response.ProductNumber.Should().Be("A");
			response.ProductSubcategoryID.Should().Be(1);
			response.ReorderPoint.Should().Be(1);
			response.ReservedClass.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SafetyStockLevel.Should().Be(1);
			response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Size.Should().Be("A");
			response.SizeUnitMeasureCode.Should().Be("A");
			response.StandardCost.Should().Be(1m);
			response.Style.Should().Be("A");
			response.Weight.Should().Be(1);
			response.WeightUnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByNameNotFound()
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
			ApiProductClientResponseModel response = await client.ByProductByName("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByProductNumberFound()
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
			ApiProductClientResponseModel response = await client.ByProductByProductNumber("A");

			response.Should().NotBeNull();

			response.Color.Should().Be("A");
			response.DaysToManufacture.Should().Be(1);
			response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FinishedGoodsFlag.Should().Be(true);
			response.ListPrice.Should().Be(1m);
			response.MakeFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductLine.Should().Be("A");
			response.ProductModelID.Should().Be(1);
			response.ProductNumber.Should().Be("A");
			response.ProductSubcategoryID.Should().Be(1);
			response.ReorderPoint.Should().Be(1);
			response.ReservedClass.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SafetyStockLevel.Should().Be(1);
			response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Size.Should().Be("A");
			response.SizeUnitMeasureCode.Should().Be("A");
			response.StandardCost.Should().Be(1m);
			response.Style.Should().Be("A");
			response.Weight.Should().Be(1);
			response.WeightUnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByProductNumberNotFound()
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
			ApiProductClientResponseModel response = await client.ByProductByProductNumber("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByRowguidFound()
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
			ApiProductClientResponseModel response = await client.ByProductByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.Color.Should().Be("A");
			response.DaysToManufacture.Should().Be(1);
			response.DiscontinuedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FinishedGoodsFlag.Should().Be(true);
			response.ListPrice.Should().Be(1m);
			response.MakeFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductID.Should().Be(1);
			response.ProductLine.Should().Be("A");
			response.ProductModelID.Should().Be(1);
			response.ProductNumber.Should().Be("A");
			response.ProductSubcategoryID.Should().Be(1);
			response.ReorderPoint.Should().Be(1);
			response.ReservedClass.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SafetyStockLevel.Should().Be(1);
			response.SellEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SellStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Size.Should().Be("A");
			response.SizeUnitMeasureCode.Should().Be("A");
			response.StandardCost.Should().Be(1m);
			response.Style.Should().Be("A");
			response.Weight.Should().Be(1);
			response.WeightUnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
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
			ApiProductClientResponseModel response = await client.ByProductByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeyBillOfMaterialsByComponentIDFound()
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
			List<ApiBillOfMaterialClientResponseModel> response = await client.BillOfMaterialsByComponentID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyBillOfMaterialsByComponentIDNotFound()
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
			List<ApiBillOfMaterialClientResponseModel> response = await client.BillOfMaterialsByComponentID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyBillOfMaterialsByProductAssemblyIDFound()
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
			List<ApiBillOfMaterialClientResponseModel> response = await client.BillOfMaterialsByProductAssemblyID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyBillOfMaterialsByProductAssemblyIDNotFound()
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
			List<ApiBillOfMaterialClientResponseModel> response = await client.BillOfMaterialsByProductAssemblyID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyProductProductPhotoesByProductIDFound()
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
			List<ApiProductProductPhotoClientResponseModel> response = await client.ProductProductPhotoesByProductID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyProductProductPhotoesByProductIDNotFound()
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
			List<ApiProductProductPhotoClientResponseModel> response = await client.ProductProductPhotoesByProductID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyProductReviewsByProductIDFound()
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
			List<ApiProductReviewClientResponseModel> response = await client.ProductReviewsByProductID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyProductReviewsByProductIDNotFound()
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
			List<ApiProductReviewClientResponseModel> response = await client.ProductReviewsByProductID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTransactionHistoriesByProductIDFound()
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
			List<ApiTransactionHistoryClientResponseModel> response = await client.TransactionHistoriesByProductID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTransactionHistoriesByProductIDNotFound()
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
			List<ApiTransactionHistoryClientResponseModel> response = await client.TransactionHistoriesByProductID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyWorkOrdersByProductIDFound()
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
			List<ApiWorkOrderClientResponseModel> response = await client.WorkOrdersByProductID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyWorkOrdersByProductIDNotFound()
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
			List<ApiWorkOrderClientResponseModel> response = await client.WorkOrdersByProductID(default(int));

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
				var result = await client.ProductAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>099e322815f63f072f940418889a61c7</Hash>
</Codenesium>*/