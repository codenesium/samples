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
	[Trait("Table", "Table")]
	[Trait("Area", "Integration")]
	public class TableIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TableIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTableModelMapper mapper = new ApiTableModelMapper();

			UpdateResponse<ApiTableResponseModel> updateResponse = await this.Client.TableUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TableDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTableResponseModel response = await this.Client.TableGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTableResponseModel> response = await this.Client.TableAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTableResponseModel> CreateRecord()
		{
			var model = new ApiTableRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTableResponseModel> result = await this.Client.TableCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TableDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>294721b0802c32205b3da55bb5142505</Hash>
</Codenesium>*/