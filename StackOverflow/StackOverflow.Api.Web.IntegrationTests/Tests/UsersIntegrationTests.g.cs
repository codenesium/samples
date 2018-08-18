using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Users")]
	[Trait("Area", "Integration")]
	public class UsersIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public UsersIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiUsersModelMapper mapper = new ApiUsersModelMapper();

			UpdateResponse<ApiUsersResponseModel> updateResponse = await this.Client.UsersUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.UsersDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiUsersResponseModel response = await this.Client.UsersGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiUsersResponseModel> response = await this.Client.UsersAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiUsersResponseModel> CreateRecord()
		{
			var model = new ApiUsersRequestModel();
			model.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			CreateResponse<ApiUsersResponseModel> result = await this.Client.UsersCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.UsersDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>130ee78655c7b81f2fe910cb2e1db933</Hash>
</Codenesium>*/