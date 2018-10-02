using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "User")]
	[Trait("Area", "Integration")]
	public class UserIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public UserIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiUserModelMapper mapper = new ApiUserModelMapper();

			UpdateResponse<ApiUserResponseModel> updateResponse = await this.Client.UserUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.UserDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiUserResponseModel response = await this.Client.UserGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiUserResponseModel> response = await this.Client.UserAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiUserResponseModel> CreateRecord()
		{
			var model = new ApiUserRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiUserResponseModel> result = await this.Client.UserCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.UserDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>4a7b1f11f317e04c242a47b62953eccd</Hash>
</Codenesium>*/