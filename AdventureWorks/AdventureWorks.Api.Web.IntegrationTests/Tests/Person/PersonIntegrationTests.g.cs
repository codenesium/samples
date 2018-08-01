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
	[Trait("Table", "Person")]
	[Trait("Area", "Integration")]
	public class PersonIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PersonIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPersonModelMapper mapper = new ApiPersonModelMapper();

			UpdateResponse<ApiPersonResponseModel> updateResponse = await this.Client.PersonUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PersonDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPersonResponseModel response = await this.Client.PersonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPersonResponseModel> response = await this.Client.PersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPersonResponseModel> CreateRecord()
		{
			var model = new ApiPersonRequestModel();
			model.SetProperties("B", "B", 2, "B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), true, "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", "B");
			CreateResponse<ApiPersonResponseModel> result = await this.Client.PersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PersonDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>e3a86b73129f7e71df3c24c78a17f2f0</Hash>
</Codenesium>*/