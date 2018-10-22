using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "Integration")]
	public class CountryRequirementIntegrationTests
	{
		public CountryRequirementIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.CountryRequirementDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiCountryRequirementResponseModel model = await client.CountryRequirementGetAsync(1);

			ApiCountryRequirementModelMapper mapper = new ApiCountryRequirementModelMapper();

			UpdateResponse<ApiCountryRequirementResponseModel> updateResponse = await client.CountryRequirementUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			var createModel = new ApiCountryRequirementRequestModel();
			createModel.SetProperties(1, "B");
			CreateResponse<ApiCountryRequirementResponseModel> createResult = await client.CountryRequirementCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiCountryRequirementResponseModel getResponse = await client.CountryRequirementGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.CountryRequirementDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiCountryRequirementResponseModel verifyResponse = await client.CountryRequirementGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCountryRequirementResponseModel response = await client.CountryRequirementGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiCountryRequirementResponseModel> response = await client.CountryRequirementAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCountryRequirementResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCountryRequirementRequestModel();
			model.SetProperties(1, "B");
			CreateResponse<ApiCountryRequirementResponseModel> result = await client.CountryRequirementCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>509761e83786b3b9e11f23fe8bd52f99</Hash>
</Codenesium>*/