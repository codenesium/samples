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
	[Trait("Table", "VariableSet")]
	[Trait("Area", "Integration")]
	public class VariableSetIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VariableSetIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVariableSetModelMapper mapper = new ApiVariableSetModelMapper();

			UpdateResponse<ApiVariableSetResponseModel> updateResponse = await this.Client.VariableSetUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VariableSetDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVariableSetResponseModel response = await this.Client.VariableSetGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVariableSetResponseModel> response = await this.Client.VariableSetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVariableSetResponseModel> CreateRecord()
		{
			var model = new ApiVariableSetRequestModel();
			model.SetProperties(true, "B", "B", "B", 2);
			CreateResponse<ApiVariableSetResponseModel> result = await this.Client.VariableSetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VariableSetDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>f8b70eb2da64adacfd8fae31602333fd</Hash>
</Codenesium>*/