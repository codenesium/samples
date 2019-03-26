using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
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

			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiPetClientRequestModel();
			model.SetProperties(1, 2, "B", 2);
			var model2 = new ApiPetClientRequestModel();
			model2.SetProperties(1, 3, "C", 3);
			var request = new List<ApiPetClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPetClientResponseModel>> result = await client.PetBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Pet>().ToList()[1].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[1].ClientId.Should().Be(2);
			context.Set<Pet>().ToList()[1].Name.Should().Be("B");
			context.Set<Pet>().ToList()[1].Weight.Should().Be(2);

			context.Set<Pet>().ToList()[2].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[2].ClientId.Should().Be(3);
			context.Set<Pet>().ToList()[2].Name.Should().Be("C");
			context.Set<Pet>().ToList()[2].Weight.Should().Be(3);
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

			var model = new ApiPetClientRequestModel();
			model.SetProperties(1, 2, "B", 2);
			CreateResponse<ApiPetClientResponseModel> result = await client.PetCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Pet>().ToList()[1].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[1].ClientId.Should().Be(2);
			context.Set<Pet>().ToList()[1].Name.Should().Be("B");
			context.Set<Pet>().ToList()[1].Weight.Should().Be(2);

			result.Record.BreedId.Should().Be(1);
			result.Record.ClientId.Should().Be(2);
			result.Record.Name.Should().Be("B");
			result.Record.Weight.Should().Be(2);
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
			var mapper = new ApiPetServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPetService service = testServer.Host.Services.GetService(typeof(IPetService)) as IPetService;
			ApiPetServerResponseModel model = await service.Get(1);

			ApiPetClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 2, "B", 2);

			UpdateResponse<ApiPetClientResponseModel> updateResponse = await client.PetUpdateAsync(model.Id, request);

			context.Entry(context.Set<Pet>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Pet>().ToList()[0].BreedId.Should().Be(1);
			context.Set<Pet>().ToList()[0].ClientId.Should().Be(2);
			context.Set<Pet>().ToList()[0].Name.Should().Be("B");
			context.Set<Pet>().ToList()[0].Weight.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.BreedId.Should().Be(1);
			updateResponse.Record.ClientId.Should().Be(2);
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Weight.Should().Be(2);
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

			IPetService service = testServer.Host.Services.GetService(typeof(IPetService)) as IPetService;
			var model = new ApiPetServerRequestModel();
			model.SetProperties(1, 2, "B", 2);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiPetClientResponseModel response = await client.PetGetAsync(1);

			response.Should().NotBeNull();
			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiPetClientResponseModel> response = await client.PetAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].BreedId.Should().Be(1);
			response[0].ClientId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Weight.Should().Be(1);
		}

		[Fact]
		public virtual async void TestForeignKeySalesByPetIdFound()
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
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
    <Hash>65ee750c7ae72bd9087534aaaaf2b6a0</Hash>
</Codenesium>*/