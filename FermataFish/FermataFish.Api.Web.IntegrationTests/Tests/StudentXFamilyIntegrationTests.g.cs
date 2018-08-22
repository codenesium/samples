using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "StudentXFamily")]
	[Trait("Area", "Integration")]
	public class StudentXFamilyIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public StudentXFamilyIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiStudentXFamilyModelMapper mapper = new ApiStudentXFamilyModelMapper();

			UpdateResponse<ApiStudentXFamilyResponseModel> updateResponse = await this.Client.StudentXFamilyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.StudentXFamilyDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiStudentXFamilyResponseModel response = await this.Client.StudentXFamilyGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiStudentXFamilyResponseModel> response = await this.Client.StudentXFamilyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStudentXFamilyResponseModel> CreateRecord()
		{
			var model = new ApiStudentXFamilyRequestModel();
			model.SetProperties(1, 1, 1);
			CreateResponse<ApiStudentXFamilyResponseModel> result = await this.Client.StudentXFamilyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.StudentXFamilyDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>eb3a11f1476867a5b86f4df0a9346df8</Hash>
</Codenesium>*/