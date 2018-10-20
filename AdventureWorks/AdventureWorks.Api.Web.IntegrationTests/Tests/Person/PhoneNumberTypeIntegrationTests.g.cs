using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "Integration")]
	public class PhoneNumberTypeIntegrationTests
	{
		public PhoneNumberTypeIntegrationTests()
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

			await client.PhoneNumberTypeDeleteAsync(1);

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

			ApiPhoneNumberTypeResponseModel model = await client.PhoneNumberTypeGetAsync(1);

			ApiPhoneNumberTypeModelMapper mapper = new ApiPhoneNumberTypeModelMapper();

			UpdateResponse<ApiPhoneNumberTypeResponseModel> updateResponse = await client.PhoneNumberTypeUpdateAsync(model.PhoneNumberTypeID, mapper.MapResponseToRequest(model));

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

			ApiPhoneNumberTypeResponseModel response = await client.PhoneNumberTypeGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PhoneNumberTypeDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PhoneNumberTypeGetAsync(1);

			response.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPhoneNumberTypeResponseModel response = await client.PhoneNumberTypeGetAsync(1);

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

			List<ApiPhoneNumberTypeResponseModel> response = await client.PhoneNumberTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPhoneNumberTypeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPhoneNumberTypeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiPhoneNumberTypeResponseModel> result = await client.PhoneNumberTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>3dad9adb8526e8689a8b2022fb392c46</Hash>
</Codenesium>*/