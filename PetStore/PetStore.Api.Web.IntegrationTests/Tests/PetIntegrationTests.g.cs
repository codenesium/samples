using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Pet")]
	[Trait("Area", "Integration")]
	public partial class PetIntegrationTests
	{
		public PetIntegrationTests()
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

			var model = new ApiPetClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B", 1, 2m, 1);
			var model2 = new ApiPetClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 1, "C", 1, 3m, 1);
			var request = new List<ApiPetClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPetClientResponseModel>> result = await client.PetBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Pet>().ToList()[1].AcquiredDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Pet>().ToList()[1].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[1].Description.Should().Be("B");
			context.Set<Pet>().ToList()[1].PenId.Should().Be(1);
			context.Set<Pet>().ToList()[1].Price.Should().Be(2m);
			context.Set<Pet>().ToList()[1].SpeciesId.Should().Be(1);

			context.Set<Pet>().ToList()[2].AcquiredDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Pet>().ToList()[2].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[2].Description.Should().Be("C");
			context.Set<Pet>().ToList()[2].PenId.Should().Be(1);
			context.Set<Pet>().ToList()[2].Price.Should().Be(3m);
			context.Set<Pet>().ToList()[2].SpeciesId.Should().Be(1);
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

			var model = new ApiPetClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B", 1, 2m, 1);
			CreateResponse<ApiPetClientResponseModel> result = await client.PetCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Pet>().ToList()[1].AcquiredDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Pet>().ToList()[1].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[1].Description.Should().Be("B");
			context.Set<Pet>().ToList()[1].PenId.Should().Be(1);
			context.Set<Pet>().ToList()[1].Price.Should().Be(2m);
			context.Set<Pet>().ToList()[1].SpeciesId.Should().Be(1);

			result.Record.AcquiredDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.BreedId.Should().Be(1);
			result.Record.Description.Should().Be("B");
			result.Record.PenId.Should().Be(1);
			result.Record.Price.Should().Be(2m);
			result.Record.SpeciesId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiPetServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPetService service = testServer.Host.Services.GetService(typeof(IPetService)) as IPetService;
			ApiPetServerResponseModel model = await service.Get(1);

			ApiPetClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B", 1, 2m, 1);

			UpdateResponse<ApiPetClientResponseModel> updateResponse = await client.PetUpdateAsync(model.Id, request);

			context.Entry(context.Set<Pet>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Pet>().ToList()[0].AcquiredDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Pet>().ToList()[0].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[0].Description.Should().Be("B");
			context.Set<Pet>().ToList()[0].PenId.Should().Be(1);
			context.Set<Pet>().ToList()[0].Price.Should().Be(2m);
			context.Set<Pet>().ToList()[0].SpeciesId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.AcquiredDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.BreedId.Should().Be(1);
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.PenId.Should().Be(1);
			updateResponse.Record.Price.Should().Be(2m);
			updateResponse.Record.SpeciesId.Should().Be(1);
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

			IPetService service = testServer.Host.Services.GetService(typeof(IPetService)) as IPetService;
			var model = new ApiPetServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B", 1, 2m, 1);
			CreateResponse<ApiPetServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPetServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPetClientResponseModel response = await client.PetGetAsync(1);

			response.Should().NotBeNull();
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPetClientResponseModel response = await client.PetGetAsync(default(int));

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

			List<ApiPetClientResponseModel> response = await client.PetAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].BreedId.Should().Be(1);
			response[0].Description.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].PenId.Should().Be(1);
			response[0].Price.Should().Be(1m);
			response[0].SpeciesId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestForeignKeySalesByPetIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSaleClientResponseModel> response = await client.SalesByPetId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesByPetIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSaleClientResponseModel> response = await client.SalesByPetId(default(int));

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
				var result = await client.PetAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>c8e212e0c672b70fbf74e313314d1f83</Hash>
</Codenesium>*/