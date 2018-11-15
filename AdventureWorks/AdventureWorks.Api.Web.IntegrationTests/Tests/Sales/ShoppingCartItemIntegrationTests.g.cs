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
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "Integration")]
	public partial class ShoppingCartItemIntegrationTests
	{
		public ShoppingCartItemIntegrationTests()
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

			var model = new ApiShoppingCartItemClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			var model2 = new ApiShoppingCartItemClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3, "C");
			var request = new List<ApiShoppingCartItemClientRequestModel>() {model, model2};
			CreateResponse<List<ApiShoppingCartItemClientResponseModel>> result = await client.ShoppingCartItemBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ShoppingCartItem>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[1].ProductID.Should().Be(2);
			context.Set<ShoppingCartItem>().ToList()[1].Quantity.Should().Be(2);
			context.Set<ShoppingCartItem>().ToList()[1].ShoppingCartID.Should().Be("B");

			context.Set<ShoppingCartItem>().ToList()[2].DateCreated.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[2].ProductID.Should().Be(3);
			context.Set<ShoppingCartItem>().ToList()[2].Quantity.Should().Be(3);
			context.Set<ShoppingCartItem>().ToList()[2].ShoppingCartID.Should().Be("C");
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

			var model = new ApiShoppingCartItemClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			CreateResponse<ApiShoppingCartItemClientResponseModel> result = await client.ShoppingCartItemCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ShoppingCartItem>().ToList()[1].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[1].ProductID.Should().Be(2);
			context.Set<ShoppingCartItem>().ToList()[1].Quantity.Should().Be(2);
			context.Set<ShoppingCartItem>().ToList()[1].ShoppingCartID.Should().Be("B");

			result.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ProductID.Should().Be(2);
			result.Record.Quantity.Should().Be(2);
			result.Record.ShoppingCartID.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiShoppingCartItemServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IShoppingCartItemService service = testServer.Host.Services.GetService(typeof(IShoppingCartItemService)) as IShoppingCartItemService;
			ApiShoppingCartItemServerResponseModel model = await service.Get(1);

			ApiShoppingCartItemClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");

			UpdateResponse<ApiShoppingCartItemClientResponseModel> updateResponse = await client.ShoppingCartItemUpdateAsync(model.ShoppingCartItemID, request);

			context.Entry(context.Set<ShoppingCartItem>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ShoppingCartItemID.Should().Be(1);
			context.Set<ShoppingCartItem>().ToList()[0].DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ShoppingCartItem>().ToList()[0].ProductID.Should().Be(2);
			context.Set<ShoppingCartItem>().ToList()[0].Quantity.Should().Be(2);
			context.Set<ShoppingCartItem>().ToList()[0].ShoppingCartID.Should().Be("B");

			updateResponse.Record.ShoppingCartItemID.Should().Be(1);
			updateResponse.Record.DateCreated.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ProductID.Should().Be(2);
			updateResponse.Record.Quantity.Should().Be(2);
			updateResponse.Record.ShoppingCartID.Should().Be("B");
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

			IShoppingCartItemService service = testServer.Host.Services.GetService(typeof(IShoppingCartItemService)) as IShoppingCartItemService;
			var model = new ApiShoppingCartItemServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			CreateResponse<ApiShoppingCartItemServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ShoppingCartItemDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiShoppingCartItemServerResponseModel verifyResponse = await service.Get(2);

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

			ApiShoppingCartItemClientResponseModel response = await client.ShoppingCartItemGetAsync(1);

			response.Should().NotBeNull();
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
			response.ShoppingCartItemID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiShoppingCartItemClientResponseModel response = await client.ShoppingCartItemGetAsync(default(int));

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

			List<ApiShoppingCartItemClientResponseModel> response = await client.ShoppingCartItemAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductID.Should().Be(1);
			response[0].Quantity.Should().Be(1);
			response[0].ShoppingCartID.Should().Be("A");
			response[0].ShoppingCartItemID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByShoppingCartIDProductIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiShoppingCartItemClientResponseModel> response = await client.ByShoppingCartItemByShoppingCartIDProductID("A", 1);

			response.Should().NotBeEmpty();
			response[0].DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductID.Should().Be(1);
			response[0].Quantity.Should().Be(1);
			response[0].ShoppingCartID.Should().Be("A");
			response[0].ShoppingCartItemID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByShoppingCartIDProductIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiShoppingCartItemClientResponseModel> response = await client.ByShoppingCartItemByShoppingCartIDProductID("test_value", default(int));

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
				var result = await client.ShoppingCartItemAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>5fed4e76d37859edad1277a9d3bd46c2</Hash>
</Codenesium>*/