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
	[Trait("Table", "Address")]
	[Trait("Area", "Integration")]
	public partial class AddressIntegrationTests
	{
		public AddressIntegrationTests()
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

			var model = new ApiAddressClientRequestModel();
			model.SetProperties("B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2);
			var model2 = new ApiAddressClientRequestModel();
			model2.SetProperties("C", "C", "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 3);
			var request = new List<ApiAddressClientRequestModel>() {model, model2};
			CreateResponse<List<ApiAddressClientResponseModel>> result = await client.AddressBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Address>().ToList()[1].AddressLine1.Should().Be("B");
			context.Set<Address>().ToList()[1].AddressLine2.Should().Be("B");
			context.Set<Address>().ToList()[1].City.Should().Be("B");
			context.Set<Address>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Address>().ToList()[1].PostalCode.Should().Be("B");
			context.Set<Address>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Address>().ToList()[1].StateProvinceID.Should().Be(2);

			context.Set<Address>().ToList()[2].AddressLine1.Should().Be("C");
			context.Set<Address>().ToList()[2].AddressLine2.Should().Be("C");
			context.Set<Address>().ToList()[2].City.Should().Be("C");
			context.Set<Address>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Address>().ToList()[2].PostalCode.Should().Be("C");
			context.Set<Address>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Address>().ToList()[2].StateProvinceID.Should().Be(3);
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

			var model = new ApiAddressClientRequestModel();
			model.SetProperties("B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2);
			CreateResponse<ApiAddressClientResponseModel> result = await client.AddressCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Address>().ToList()[1].AddressLine1.Should().Be("B");
			context.Set<Address>().ToList()[1].AddressLine2.Should().Be("B");
			context.Set<Address>().ToList()[1].City.Should().Be("B");
			context.Set<Address>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Address>().ToList()[1].PostalCode.Should().Be("B");
			context.Set<Address>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Address>().ToList()[1].StateProvinceID.Should().Be(2);

			result.Record.AddressLine1.Should().Be("B");
			result.Record.AddressLine2.Should().Be("B");
			result.Record.City.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PostalCode.Should().Be("B");
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.StateProvinceID.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiAddressServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IAddressService service = testServer.Host.Services.GetService(typeof(IAddressService)) as IAddressService;
			ApiAddressServerResponseModel model = await service.Get(1);

			ApiAddressClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2);

			UpdateResponse<ApiAddressClientResponseModel> updateResponse = await client.AddressUpdateAsync(model.AddressID, request);

			context.Entry(context.Set<Address>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.AddressID.Should().Be(1);
			context.Set<Address>().ToList()[0].AddressLine1.Should().Be("B");
			context.Set<Address>().ToList()[0].AddressLine2.Should().Be("B");
			context.Set<Address>().ToList()[0].City.Should().Be("B");
			context.Set<Address>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Address>().ToList()[0].PostalCode.Should().Be("B");
			context.Set<Address>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Address>().ToList()[0].StateProvinceID.Should().Be(2);

			updateResponse.Record.AddressID.Should().Be(1);
			updateResponse.Record.AddressLine1.Should().Be("B");
			updateResponse.Record.AddressLine2.Should().Be("B");
			updateResponse.Record.City.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PostalCode.Should().Be("B");
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.StateProvinceID.Should().Be(2);
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

			IAddressService service = testServer.Host.Services.GetService(typeof(IAddressService)) as IAddressService;
			var model = new ApiAddressServerRequestModel();
			model.SetProperties("B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2);
			CreateResponse<ApiAddressServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.AddressDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiAddressServerResponseModel verifyResponse = await service.Get(2);

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

			ApiAddressClientResponseModel response = await client.AddressGetAsync(1);

			response.Should().NotBeNull();
			response.AddressID.Should().Be(1);
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiAddressClientResponseModel response = await client.AddressGetAsync(default(int));

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

			List<ApiAddressClientResponseModel> response = await client.AddressAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AddressID.Should().Be(1);
			response[0].AddressLine1.Should().Be("A");
			response[0].AddressLine2.Should().Be("A");
			response[0].City.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PostalCode.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].StateProvinceID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRowguidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiAddressClientResponseModel response = await client.ByAddressByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.AddressID.Should().Be(1);
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiAddressClientResponseModel response = await client.ByAddressByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByAddressLine1AddressLine2CityStateProvinceIDPostalCodeFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiAddressClientResponseModel response = await client.ByAddressByAddressLine1AddressLine2CityStateProvinceIDPostalCode("A", "A", "A", 1, "A");

			response.Should().NotBeNull();

			response.AddressID.Should().Be(1);
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByAddressLine1AddressLine2CityStateProvinceIDPostalCodeNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiAddressClientResponseModel response = await client.ByAddressByAddressLine1AddressLine2CityStateProvinceIDPostalCode("test_value", "test_value", "test_value", default(int), "test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByStateProvinceIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiAddressClientResponseModel> response = await client.ByAddressByStateProvinceID(1);

			response.Should().NotBeEmpty();
			response[0].AddressID.Should().Be(1);
			response[0].AddressLine1.Should().Be("A");
			response[0].AddressLine2.Should().Be("A");
			response[0].City.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PostalCode.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].StateProvinceID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByStateProvinceIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiAddressClientResponseModel> response = await client.ByAddressByStateProvinceID(default(int));

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
				var result = await client.AddressAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>0c7a2592863ea4724d0b811c77f1a3cc</Hash>
</Codenesium>*/