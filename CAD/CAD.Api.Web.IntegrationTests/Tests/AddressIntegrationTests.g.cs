using CADNS.Api.Client;
using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web.IntegrationTests
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
			model.SetProperties("B", "B", "B", "B", "B");
			var model2 = new ApiAddressClientRequestModel();
			model2.SetProperties("C", "C", "C", "C", "C");
			var request = new List<ApiAddressClientRequestModel>() {model, model2};
			CreateResponse<List<ApiAddressClientResponseModel>> result = await client.AddressBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Address>().ToList()[1].Address1.Should().Be("B");
			context.Set<Address>().ToList()[1].Address2.Should().Be("B");
			context.Set<Address>().ToList()[1].City.Should().Be("B");
			context.Set<Address>().ToList()[1].State.Should().Be("B");
			context.Set<Address>().ToList()[1].Zip.Should().Be("B");

			context.Set<Address>().ToList()[2].Address1.Should().Be("C");
			context.Set<Address>().ToList()[2].Address2.Should().Be("C");
			context.Set<Address>().ToList()[2].City.Should().Be("C");
			context.Set<Address>().ToList()[2].State.Should().Be("C");
			context.Set<Address>().ToList()[2].Zip.Should().Be("C");
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
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiAddressClientResponseModel> result = await client.AddressCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Address>().ToList()[1].Address1.Should().Be("B");
			context.Set<Address>().ToList()[1].Address2.Should().Be("B");
			context.Set<Address>().ToList()[1].City.Should().Be("B");
			context.Set<Address>().ToList()[1].State.Should().Be("B");
			context.Set<Address>().ToList()[1].Zip.Should().Be("B");

			result.Record.Address1.Should().Be("B");
			result.Record.Address2.Should().Be("B");
			result.Record.City.Should().Be("B");
			result.Record.State.Should().Be("B");
			result.Record.Zip.Should().Be("B");
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
			request.SetProperties("B", "B", "B", "B", "B");

			UpdateResponse<ApiAddressClientResponseModel> updateResponse = await client.AddressUpdateAsync(model.Id, request);

			context.Entry(context.Set<Address>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Address>().ToList()[0].Address1.Should().Be("B");
			context.Set<Address>().ToList()[0].Address2.Should().Be("B");
			context.Set<Address>().ToList()[0].City.Should().Be("B");
			context.Set<Address>().ToList()[0].State.Should().Be("B");
			context.Set<Address>().ToList()[0].Zip.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Address1.Should().Be("B");
			updateResponse.Record.Address2.Should().Be("B");
			updateResponse.Record.City.Should().Be("B");
			updateResponse.Record.State.Should().Be("B");
			updateResponse.Record.Zip.Should().Be("B");
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
			model.SetProperties("B", "B", "B", "B", "B");
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
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Id.Should().Be(1);
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
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
			response[0].Address1.Should().Be("A");
			response[0].Address2.Should().Be("A");
			response[0].City.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].State.Should().Be("A");
			response[0].Zip.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyCallsByAddressIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCallClientResponseModel> response = await client.CallsByAddressId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCallsByAddressIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCallClientResponseModel> response = await client.CallsByAddressId(default(int));

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
    <Hash>54b424e533f30748d8e614db063e2a83</Hash>
</Codenesium>*/