using FileServiceNS.Api.Client;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "FileType")]
	[Trait("Area", "Integration")]
	public class FileTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public FileTypeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiFileTypeModelMapper mapper = new ApiFileTypeModelMapper();

			UpdateResponse<ApiFileTypeResponseModel> updateResponse = await this.Client.FileTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.FileTypeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiFileTypeResponseModel response = await this.Client.FileTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiFileTypeResponseModel> response = await this.Client.FileTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFileTypeResponseModel> CreateRecord()
		{
			var model = new ApiFileTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiFileTypeResponseModel> result = await this.Client.FileTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.FileTypeDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>f7452f1e00248634fc29035ee9463ba7</Hash>
</Codenesium>*/