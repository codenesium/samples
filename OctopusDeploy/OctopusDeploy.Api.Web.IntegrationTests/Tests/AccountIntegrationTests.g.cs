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
	[Trait("Table", "Account")]
	[Trait("Area", "Integration")]
	public class AccountIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public AccountIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiAccountModelMapper mapper = new ApiAccountModelMapper();

			UpdateResponse<ApiAccountResponseModel> updateResponse = await this.Client.AccountUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.AccountDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiAccountResponseModel response = await this.Client.AccountGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiAccountResponseModel> response = await this.Client.AccountAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAccountResponseModel> CreateRecord()
		{
			var model = new ApiAccountRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B");
			CreateResponse<ApiAccountResponseModel> result = await this.Client.AccountCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.AccountDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>8739c81a36d19d39133f8ac10a8c19a8</Hash>
</Codenesium>*/