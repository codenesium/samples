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
	[Trait("Table", "Student")]
	[Trait("Area", "Integration")]
	public class StudentIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public StudentIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiStudentModelMapper mapper = new ApiStudentModelMapper();

			UpdateResponse<ApiStudentResponseModel> updateResponse = await this.Client.StudentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.StudentDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiStudentResponseModel response = await this.Client.StudentGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiStudentResponseModel> response = await this.Client.StudentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStudentResponseModel> CreateRecord()
		{
			var model = new ApiStudentRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, 1, "B", true, "B", "B", true, 1);
			CreateResponse<ApiStudentResponseModel> result = await this.Client.StudentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.StudentDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>c16909855b7ce365e8885233737c4480</Hash>
</Codenesium>*/