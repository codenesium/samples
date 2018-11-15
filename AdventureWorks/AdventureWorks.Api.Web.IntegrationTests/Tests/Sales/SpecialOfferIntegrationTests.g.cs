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
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "Integration")]
	public partial class SpecialOfferIntegrationTests
	{
		public SpecialOfferIntegrationTests()
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

			var model = new ApiSpecialOfferClientRequestModel();
			model.SetProperties("B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiSpecialOfferClientRequestModel();
			model2.SetProperties("C", "C", 3m, DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiSpecialOfferClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSpecialOfferClientResponseModel>> result = await client.SpecialOfferBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SpecialOffer>().ToList()[1].Category.Should().Be("B");
			context.Set<SpecialOffer>().ToList()[1].Description.Should().Be("B");
			context.Set<SpecialOffer>().ToList()[1].DiscountPct.Should().Be(2m);
			context.Set<SpecialOffer>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[1].MaxQty.Should().Be(2);
			context.Set<SpecialOffer>().ToList()[1].MinQty.Should().Be(2);
			context.Set<SpecialOffer>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SpecialOffer>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[1].Type.Should().Be("B");

			context.Set<SpecialOffer>().ToList()[2].Category.Should().Be("C");
			context.Set<SpecialOffer>().ToList()[2].Description.Should().Be("C");
			context.Set<SpecialOffer>().ToList()[2].DiscountPct.Should().Be(3m);
			context.Set<SpecialOffer>().ToList()[2].EndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[2].MaxQty.Should().Be(3);
			context.Set<SpecialOffer>().ToList()[2].MinQty.Should().Be(3);
			context.Set<SpecialOffer>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<SpecialOffer>().ToList()[2].StartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[2].Type.Should().Be("C");
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

			var model = new ApiSpecialOfferClientRequestModel();
			model.SetProperties("B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiSpecialOfferClientResponseModel> result = await client.SpecialOfferCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SpecialOffer>().ToList()[1].Category.Should().Be("B");
			context.Set<SpecialOffer>().ToList()[1].Description.Should().Be("B");
			context.Set<SpecialOffer>().ToList()[1].DiscountPct.Should().Be(2m);
			context.Set<SpecialOffer>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[1].MaxQty.Should().Be(2);
			context.Set<SpecialOffer>().ToList()[1].MinQty.Should().Be(2);
			context.Set<SpecialOffer>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SpecialOffer>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[1].Type.Should().Be("B");

			result.Record.Category.Should().Be("B");
			result.Record.Description.Should().Be("B");
			result.Record.DiscountPct.Should().Be(2m);
			result.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.MaxQty.Should().Be(2);
			result.Record.MinQty.Should().Be(2);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Type.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiSpecialOfferServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISpecialOfferService service = testServer.Host.Services.GetService(typeof(ISpecialOfferService)) as ISpecialOfferService;
			ApiSpecialOfferServerResponseModel model = await service.Get(1);

			ApiSpecialOfferClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiSpecialOfferClientResponseModel> updateResponse = await client.SpecialOfferUpdateAsync(model.SpecialOfferID, request);

			context.Entry(context.Set<SpecialOffer>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.SpecialOfferID.Should().Be(1);
			context.Set<SpecialOffer>().ToList()[0].Category.Should().Be("B");
			context.Set<SpecialOffer>().ToList()[0].Description.Should().Be("B");
			context.Set<SpecialOffer>().ToList()[0].DiscountPct.Should().Be(2m);
			context.Set<SpecialOffer>().ToList()[0].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[0].MaxQty.Should().Be(2);
			context.Set<SpecialOffer>().ToList()[0].MinQty.Should().Be(2);
			context.Set<SpecialOffer>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SpecialOffer>().ToList()[0].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().ToList()[0].Type.Should().Be("B");

			updateResponse.Record.SpecialOfferID.Should().Be(1);
			updateResponse.Record.Category.Should().Be("B");
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.DiscountPct.Should().Be(2m);
			updateResponse.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.MaxQty.Should().Be(2);
			updateResponse.Record.MinQty.Should().Be(2);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Type.Should().Be("B");
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

			ISpecialOfferService service = testServer.Host.Services.GetService(typeof(ISpecialOfferService)) as ISpecialOfferService;
			var model = new ApiSpecialOfferServerRequestModel();
			model.SetProperties("B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiSpecialOfferServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SpecialOfferDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSpecialOfferServerResponseModel verifyResponse = await service.Get(2);

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

			ApiSpecialOfferClientResponseModel response = await client.SpecialOfferGetAsync(1);

			response.Should().NotBeNull();
			response.Category.Should().Be("A");
			response.Description.Should().Be("A");
			response.DiscountPct.Should().Be(1m);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxQty.Should().Be(1);
			response.MinQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SpecialOfferID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Type.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSpecialOfferClientResponseModel response = await client.SpecialOfferGetAsync(default(int));

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

			List<ApiSpecialOfferClientResponseModel> response = await client.SpecialOfferAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Category.Should().Be("A");
			response[0].Description.Should().Be("A");
			response[0].DiscountPct.Should().Be(1m);
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].MaxQty.Should().Be(1);
			response[0].MinQty.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SpecialOfferID.Should().Be(1);
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Type.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByRowguidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSpecialOfferClientResponseModel response = await client.BySpecialOfferByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.Category.Should().Be("A");
			response.Description.Should().Be("A");
			response.DiscountPct.Should().Be(1m);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxQty.Should().Be(1);
			response.MinQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SpecialOfferID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Type.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSpecialOfferClientResponseModel response = await client.BySpecialOfferByRowguid(default(Guid));

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
				var result = await client.SpecialOfferAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>7f4a4f64f1b308e6d7f2f2815cd96f94</Hash>
</Codenesium>*/