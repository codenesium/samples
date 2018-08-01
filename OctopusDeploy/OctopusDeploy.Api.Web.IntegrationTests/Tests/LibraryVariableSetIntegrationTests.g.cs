using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "LibraryVariableSet")]
	[Trait("Area", "Integration")]
	public class LibraryVariableSetIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public LibraryVariableSetIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiLibraryVariableSetModelMapper mapper = new ApiLibraryVariableSetModelMapper();

			UpdateResponse<ApiLibraryVariableSetResponseModel> updateResponse = await this.Client.LibraryVariableSetUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.LibraryVariableSetDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiLibraryVariableSetResponseModel response = await this.Client.LibraryVariableSetGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiLibraryVariableSetResponseModel> response = await this.Client.LibraryVariableSetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLibraryVariableSetResponseModel> CreateRecord()
		{
			var model = new ApiLibraryVariableSetRequestModel();
			model.SetProperties("B", "B", "B", "B");
			CreateResponse<ApiLibraryVariableSetResponseModel> result = await this.Client.LibraryVariableSetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.LibraryVariableSetDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>19593d977f9657e1f111d2666710cdac</Hash>
</Codenesium>*/