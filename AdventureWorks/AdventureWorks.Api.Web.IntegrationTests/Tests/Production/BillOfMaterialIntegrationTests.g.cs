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
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "Integration")]
	public partial class BillOfMaterialIntegrationTests
	{
		public BillOfMaterialIntegrationTests()
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

			var model = new ApiBillOfMaterialClientRequestModel();
			model.SetProperties(2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			var model2 = new ApiBillOfMaterialClientRequestModel();
			model2.SetProperties(3, 1, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 1, DateTime.Parse("1/1/1989 12:00:00 AM"), "A");
			var request = new List<ApiBillOfMaterialClientRequestModel>() {model, model2};
			CreateResponse<List<ApiBillOfMaterialClientResponseModel>> result = await client.BillOfMaterialBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<BillOfMaterial>().ToList()[1].BOMLevel.Should().Be(2);
			context.Set<BillOfMaterial>().ToList()[1].ComponentID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[1].PerAssemblyQty.Should().Be(2);
			context.Set<BillOfMaterial>().ToList()[1].ProductAssemblyID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[1].UnitMeasureCode.Should().Be("A");

			context.Set<BillOfMaterial>().ToList()[2].BOMLevel.Should().Be(3);
			context.Set<BillOfMaterial>().ToList()[2].ComponentID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[2].EndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[2].PerAssemblyQty.Should().Be(3);
			context.Set<BillOfMaterial>().ToList()[2].ProductAssemblyID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[2].StartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[2].UnitMeasureCode.Should().Be("A");
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

			var model = new ApiBillOfMaterialClientRequestModel();
			model.SetProperties(2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			CreateResponse<ApiBillOfMaterialClientResponseModel> result = await client.BillOfMaterialCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<BillOfMaterial>().ToList()[1].BOMLevel.Should().Be(2);
			context.Set<BillOfMaterial>().ToList()[1].ComponentID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[1].PerAssemblyQty.Should().Be(2);
			context.Set<BillOfMaterial>().ToList()[1].ProductAssemblyID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[1].UnitMeasureCode.Should().Be("A");

			result.Record.BOMLevel.Should().Be(2);
			result.Record.ComponentID.Should().Be(1);
			result.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PerAssemblyQty.Should().Be(2);
			result.Record.ProductAssemblyID.Should().Be(1);
			result.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.UnitMeasureCode.Should().Be("A");
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
			var mapper = new ApiBillOfMaterialServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IBillOfMaterialService service = testServer.Host.Services.GetService(typeof(IBillOfMaterialService)) as IBillOfMaterialService;
			ApiBillOfMaterialServerResponseModel model = await service.Get(1);

			ApiBillOfMaterialClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");

			UpdateResponse<ApiBillOfMaterialClientResponseModel> updateResponse = await client.BillOfMaterialUpdateAsync(model.BillOfMaterialsID, request);

			context.Entry(context.Set<BillOfMaterial>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.BillOfMaterialsID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[0].BOMLevel.Should().Be(2);
			context.Set<BillOfMaterial>().ToList()[0].ComponentID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[0].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[0].PerAssemblyQty.Should().Be(2);
			context.Set<BillOfMaterial>().ToList()[0].ProductAssemblyID.Should().Be(1);
			context.Set<BillOfMaterial>().ToList()[0].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<BillOfMaterial>().ToList()[0].UnitMeasureCode.Should().Be("A");

			updateResponse.Record.BillOfMaterialsID.Should().Be(1);
			updateResponse.Record.BOMLevel.Should().Be(2);
			updateResponse.Record.ComponentID.Should().Be(1);
			updateResponse.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PerAssemblyQty.Should().Be(2);
			updateResponse.Record.ProductAssemblyID.Should().Be(1);
			updateResponse.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.UnitMeasureCode.Should().Be("A");
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

			IBillOfMaterialService service = testServer.Host.Services.GetService(typeof(IBillOfMaterialService)) as IBillOfMaterialService;
			var model = new ApiBillOfMaterialServerRequestModel();
			model.SetProperties(2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "A");
			CreateResponse<ApiBillOfMaterialServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.BillOfMaterialDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiBillOfMaterialServerResponseModel verifyResponse = await service.Get(2);

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

			ApiBillOfMaterialClientResponseModel response = await client.BillOfMaterialGetAsync(1);

			response.Should().NotBeNull();
			response.BillOfMaterialsID.Should().Be(1);
			response.BOMLevel.Should().Be(1);
			response.ComponentID.Should().Be(1);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PerAssemblyQty.Should().Be(1);
			response.ProductAssemblyID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UnitMeasureCode.Should().Be("A");
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
			ApiBillOfMaterialClientResponseModel response = await client.BillOfMaterialGetAsync(default(int));

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
			List<ApiBillOfMaterialClientResponseModel> response = await client.BillOfMaterialAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].BillOfMaterialsID.Should().Be(1);
			response[0].BOMLevel.Should().Be(1);
			response[0].ComponentID.Should().Be(1);
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PerAssemblyQty.Should().Be(1);
			response[0].ProductAssemblyID.Should().Be(1);
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByUnitMeasureCodeFound()
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
			List<ApiBillOfMaterialClientResponseModel> response = await client.ByBillOfMaterialByUnitMeasureCode("A");

			response.Should().NotBeEmpty();
			response[0].BillOfMaterialsID.Should().Be(1);
			response[0].BOMLevel.Should().Be(1);
			response[0].ComponentID.Should().Be(1);
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PerAssemblyQty.Should().Be(1);
			response[0].ProductAssemblyID.Should().Be(1);
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByUnitMeasureCodeNotFound()
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
			List<ApiBillOfMaterialClientResponseModel> response = await client.ByBillOfMaterialByUnitMeasureCode("test_value");

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
				var result = await client.BillOfMaterialAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>fff401355f8ba3d17736c908ad82057e</Hash>
</Codenesium>*/