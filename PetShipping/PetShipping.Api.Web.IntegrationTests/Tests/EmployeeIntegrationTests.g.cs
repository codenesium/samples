using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Employee")]
        [Trait("Area", "Integration")]
        public class EmployeeIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public EmployeeIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiEmployeeModelMapper mapper = new ApiEmployeeModelMapper();

                        UpdateResponse<ApiEmployeeResponseModel> updateResponse = await this.Client.EmployeeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.EmployeeDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiEmployeeResponseModel response = await this.Client.EmployeeGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiEmployeeResponseModel> response = await this.Client.EmployeeAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiEmployeeResponseModel> CreateRecord()
                {
                        var model = new ApiEmployeeRequestModel();
                        model.SetProperties("B", true, true, "B");
                        CreateResponse<ApiEmployeeResponseModel> result = await this.Client.EmployeeCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.EmployeeDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>484eb81a9d69f6aa5e7012d888f537c4</Hash>
</Codenesium>*/