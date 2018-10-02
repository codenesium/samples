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
	[Trait("Table", "VPerson")]
	[Trait("Area", "Integration")]
	public class VPersonIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VPersonIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVPersonModelMapper mapper = new ApiVPersonModelMapper();

			UpdateResponse<ApiVPersonResponseModel> updateResponse = await this.Client.VPersonUpdateAsync(model.PersonId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VPersonDeleteAsync(model.PersonId);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVPersonResponseModel response = await this.Client.VPersonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVPersonResponseModel> response = await this.Client.VPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVPersonResponseModel> CreateRecord()
		{
			var model = new ApiVPersonRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiVPersonResponseModel> result = await this.Client.VPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VPersonDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>09e5c36954dc4fc3b3ce011145740690</Hash>
</Codenesium>*/