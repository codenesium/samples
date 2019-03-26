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
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "Integration")]
	public partial class CountryRequirementIntegrationTests
	{
		public CountryRequirementIntegrationTests()
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

			var model = new ApiCountryRequirementClientRequestModel();
			model.SetProperties(1, "B");
			var model2 = new ApiCountryRequirementClientRequestModel();
			model2.SetProperties(1, "C");
			var request = new List<ApiCountryRequirementClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCountryRequirementClientResponseModel>> result = await client.CountryRequirementBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<CountryRequirement>().ToList()[1].CountryId.Should().Be(1);
			context.Set<CountryRequirement>().ToList()[1].Detail.Should().Be("B");

			context.Set<CountryRequirement>().ToList()[2].CountryId.Should().Be(1);
			context.Set<CountryRequirement>().ToList()[2].Detail.Should().Be("C");
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

			var model = new ApiCountryRequirementClientRequestModel();
			model.SetProperties(1, "B");
			CreateResponse<ApiCountryRequirementClientResponseModel> result = await client.CountryRequirementCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<CountryRequirement>().ToList()[1].CountryId.Should().Be(1);
			context.Set<CountryRequirement>().ToList()[1].Detail.Should().Be("B");

			result.Record.CountryId.Should().Be(1);
			result.Record.Detail.Should().Be("B");
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
			var mapper = new ApiCountryRequirementServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICountryRequirementService service = testServer.Host.Services.GetService(typeof(ICountryRequirementService)) as ICountryRequirementService;
			ApiCountryRequirementServerResponseModel model = await service.Get(1);

			ApiCountryRequirementClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, "B");

			UpdateResponse<ApiCountryRequirementClientResponseModel> updateResponse = await client.CountryRequirementUpdateAsync(model.Id, request);

			context.Entry(context.Set<CountryRequirement>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<CountryRequirement>().ToList()[0].CountryId.Should().Be(1);
			context.Set<CountryRequirement>().ToList()[0].Detail.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CountryId.Should().Be(1);
			updateResponse.Record.Detail.Should().Be("B");
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

			ICountryRequirementService service = testServer.Host.Services.GetService(typeof(ICountryRequirementService)) as ICountryRequirementService;
			var model = new ApiCountryRequirementServerRequestModel();
			model.SetProperties(1, "B");
			CreateResponse<ApiCountryRequirementServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CountryRequirementDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCountryRequirementServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCountryRequirementClientResponseModel response = await client.CountryRequirementGetAsync(1);

			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Detail.Should().Be("A");
			response.Id.Should().Be(1);
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
			ApiCountryRequirementClientResponseModel response = await client.CountryRequirementGetAsync(default(int));

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
			List<ApiCountryRequirementClientResponseModel> response = await client.CountryRequirementAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CountryId.Should().Be(1);
			response[0].Detail.Should().Be("A");
			response[0].Id.Should().Be(1);
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
				var result = await client.CountryRequirementAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>4156a6ee1a50e73a14ce5c7b16178bdf</Hash>
</Codenesium>*/