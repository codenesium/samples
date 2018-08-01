using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "PersonRef")]
	[Trait("Area", "Integration")]
	public class PersonRefIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PersonRefIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestCreate()
		{
			var response = await this.CreateRecord();

			response.Should().NotBeNull();

			await this.Cleanup();
		}

		[Fact]
		public async void TestUpdate()
		{
			var model = await this.CreateRecord();

			ApiPersonRefModelMapper mapper = new ApiPersonRefModelMapper();

			UpdateResponse<ApiPersonRefResponseModel> updateResponse = await this.Client.PersonRefUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PersonRefDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPersonRefResponseModel response = await this.Client.PersonRefGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPersonRefResponseModel> response = await this.Client.PersonRefAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPersonRefResponseModel> CreateRecord()
		{
			var model = new ApiPersonRefRequestModel();
			model.SetProperties(2, 1);
			CreateResponse<ApiPersonRefResponseModel> result = await this.Client.PersonRefCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PersonRefDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>6c33fa4574c3fb30c9a3693c6f5cab83</Hash>
</Codenesium>*/