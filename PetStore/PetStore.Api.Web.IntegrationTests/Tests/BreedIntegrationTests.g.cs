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
	[Trait("Table", "Breed")]
	[Trait("Area", "Integration")]
	public partial class BreedIntegrationTests
	{
		public BreedIntegrationTests()
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

			var model = new ApiBreedClientRequestModel();
			model.SetProperties("B", 1);
			var model2 = new ApiBreedClientRequestModel();
			model2.SetProperties("C", 1);
			var request = new List<ApiBreedClientRequestModel>() {model, model2};
			CreateResponse<List<ApiBreedClientResponseModel>> result = await client.BreedBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Breed>().ToList()[1].Name.Should().Be("B");
			context.Set<Breed>().ToList()[1].SpeciesId.Should().Be(1);

			context.Set<Breed>().ToList()[2].Name.Should().Be("C");
			context.Set<Breed>().ToList()[2].SpeciesId.Should().Be(1);
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

			var model = new ApiBreedClientRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiBreedClientResponseModel> result = await client.BreedCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Breed>().ToList()[1].Name.Should().Be("B");
			context.Set<Breed>().ToList()[1].SpeciesId.Should().Be(1);

			result.Record.Name.Should().Be("B");
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
			var mapper = new ApiBreedServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IBreedService service = testServer.Host.Services.GetService(typeof(IBreedService)) as IBreedService;
			ApiBreedServerResponseModel model = await service.Get(1);

			ApiBreedClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 1);

			UpdateResponse<ApiBreedClientResponseModel> updateResponse = await client.BreedUpdateAsync(model.Id, request);

			context.Entry(context.Set<Breed>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Breed>().ToList()[0].Name.Should().Be("B");
			context.Set<Breed>().ToList()[0].SpeciesId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Name.Should().Be("B");
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

			IBreedService service = testServer.Host.Services.GetService(typeof(IBreedService)) as IBreedService;
			var model = new ApiBreedServerRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiBreedServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.BreedDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiBreedServerResponseModel verifyResponse = await service.Get(2);

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

			ApiBreedClientResponseModel response = await client.BreedGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
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
			ApiBreedClientResponseModel response = await client.BreedGetAsync(default(int));

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

			List<ApiBreedClientResponseModel> response = await client.BreedAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].SpeciesId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySpeciesIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiBreedClientResponseModel> response = await client.ByBreedBySpeciesId(1);

			response.Should().NotBeEmpty();
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].SpeciesId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySpeciesIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiBreedClientResponseModel> response = await client.ByBreedBySpeciesId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPetsByBreedIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPetClientResponseModel> response = await client.PetsByBreedId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPetsByBreedIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPetClientResponseModel> response = await client.PetsByBreedId(default(int));

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
				var result = await client.BreedAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>6789c501d3663941b97ebe3496b373c5</Hash>
</Codenesium>*/