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
	[Trait("Table", "StateProvince")]
	[Trait("Area", "Integration")]
	public partial class StateProvinceIntegrationTests
	{
		public StateProvinceIntegrationTests()
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

			var model = new ApiStateProvinceClientRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 2);
			var model2 = new ApiStateProvinceClientRequestModel();
			model2.SetProperties("A", true, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), "C", 3);
			var request = new List<ApiStateProvinceClientRequestModel>() {model, model2};
			CreateResponse<List<ApiStateProvinceClientResponseModel>> result = await client.StateProvinceBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<StateProvince>().ToList()[1].CountryRegionCode.Should().Be("A");
			context.Set<StateProvince>().ToList()[1].IsOnlyStateProvinceFlag.Should().Be(true);
			context.Set<StateProvince>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<StateProvince>().ToList()[1].Name.Should().Be("B");
			context.Set<StateProvince>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<StateProvince>().ToList()[1].StateProvinceCode.Should().Be("B");
			context.Set<StateProvince>().ToList()[1].TerritoryID.Should().Be(2);

			context.Set<StateProvince>().ToList()[2].CountryRegionCode.Should().Be("A");
			context.Set<StateProvince>().ToList()[2].IsOnlyStateProvinceFlag.Should().Be(true);
			context.Set<StateProvince>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<StateProvince>().ToList()[2].Name.Should().Be("C");
			context.Set<StateProvince>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<StateProvince>().ToList()[2].StateProvinceCode.Should().Be("C");
			context.Set<StateProvince>().ToList()[2].TerritoryID.Should().Be(3);
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

			var model = new ApiStateProvinceClientRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 2);
			CreateResponse<ApiStateProvinceClientResponseModel> result = await client.StateProvinceCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<StateProvince>().ToList()[1].CountryRegionCode.Should().Be("A");
			context.Set<StateProvince>().ToList()[1].IsOnlyStateProvinceFlag.Should().Be(true);
			context.Set<StateProvince>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<StateProvince>().ToList()[1].Name.Should().Be("B");
			context.Set<StateProvince>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<StateProvince>().ToList()[1].StateProvinceCode.Should().Be("B");
			context.Set<StateProvince>().ToList()[1].TerritoryID.Should().Be(2);

			result.Record.CountryRegionCode.Should().Be("A");
			result.Record.IsOnlyStateProvinceFlag.Should().Be(true);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Name.Should().Be("B");
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.StateProvinceCode.Should().Be("B");
			result.Record.TerritoryID.Should().Be(2);
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
			var mapper = new ApiStateProvinceServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IStateProvinceService service = testServer.Host.Services.GetService(typeof(IStateProvinceService)) as IStateProvinceService;
			ApiStateProvinceServerResponseModel model = await service.Get(1);

			ApiStateProvinceClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("A", true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 2);

			UpdateResponse<ApiStateProvinceClientResponseModel> updateResponse = await client.StateProvinceUpdateAsync(model.StateProvinceID, request);

			context.Entry(context.Set<StateProvince>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.StateProvinceID.Should().Be(1);
			context.Set<StateProvince>().ToList()[0].CountryRegionCode.Should().Be("A");
			context.Set<StateProvince>().ToList()[0].IsOnlyStateProvinceFlag.Should().Be(true);
			context.Set<StateProvince>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<StateProvince>().ToList()[0].Name.Should().Be("B");
			context.Set<StateProvince>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<StateProvince>().ToList()[0].StateProvinceCode.Should().Be("B");
			context.Set<StateProvince>().ToList()[0].TerritoryID.Should().Be(2);

			updateResponse.Record.StateProvinceID.Should().Be(1);
			updateResponse.Record.CountryRegionCode.Should().Be("A");
			updateResponse.Record.IsOnlyStateProvinceFlag.Should().Be(true);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.StateProvinceCode.Should().Be("B");
			updateResponse.Record.TerritoryID.Should().Be(2);
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

			IStateProvinceService service = testServer.Host.Services.GetService(typeof(IStateProvinceService)) as IStateProvinceService;
			var model = new ApiStateProvinceServerRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 2);
			CreateResponse<ApiStateProvinceServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.StateProvinceDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiStateProvinceServerResponseModel verifyResponse = await service.Get(2);

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

			ApiStateProvinceClientResponseModel response = await client.StateProvinceGetAsync(1);

			response.Should().NotBeNull();
			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
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
			ApiStateProvinceClientResponseModel response = await client.StateProvinceGetAsync(default(int));

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
			List<ApiStateProvinceClientResponseModel> response = await client.StateProvinceAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CountryRegionCode.Should().Be("A");
			response[0].IsOnlyStateProvinceFlag.Should().Be(true);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Name.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].StateProvinceCode.Should().Be("A");
			response[0].StateProvinceID.Should().Be(1);
			response[0].TerritoryID.Should().Be(1);
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
			ApiStateProvinceClientResponseModel response = await client.ByStateProvinceByName("A");

			response.Should().NotBeNull();

			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
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
			ApiStateProvinceClientResponseModel response = await client.ByStateProvinceByName("test_value");

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
			ApiStateProvinceClientResponseModel response = await client.ByStateProvinceByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
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
			ApiStateProvinceClientResponseModel response = await client.ByStateProvinceByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByStateProvinceCodeCountryRegionCodeFound()
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
			ApiStateProvinceClientResponseModel response = await client.ByStateProvinceByStateProvinceCodeCountryRegionCode("A", "A");

			response.Should().NotBeNull();

			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByStateProvinceCodeCountryRegionCodeNotFound()
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
			ApiStateProvinceClientResponseModel response = await client.ByStateProvinceByStateProvinceCodeCountryRegionCode("test_value", "test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeyAddressesByStateProvinceIDFound()
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
			List<ApiAddressClientResponseModel> response = await client.AddressesByStateProvinceID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyAddressesByStateProvinceIDNotFound()
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
			List<ApiAddressClientResponseModel> response = await client.AddressesByStateProvinceID(default(int));

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
				var result = await client.StateProvinceAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>402498cc18f6a9dc52f3d1977beb57b1</Hash>
</Codenesium>*/