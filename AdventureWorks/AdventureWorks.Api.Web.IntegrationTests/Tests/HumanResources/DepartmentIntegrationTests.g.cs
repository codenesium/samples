using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Department")]
        [Trait("Area", "Integration")]
        public class DepartmentIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public DepartmentIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiDepartmentModelMapper mapper = new ApiDepartmentModelMapper();

                        UpdateResponse<ApiDepartmentResponseModel> updateResponse = await this.Client.DepartmentUpdateAsync(model.DepartmentID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.DepartmentDeleteAsync(model.DepartmentID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiDepartmentResponseModel response = await this.Client.DepartmentGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiDepartmentResponseModel> response = await this.Client.DepartmentAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiDepartmentResponseModel> CreateRecord()
                {
                        var model = new ApiDepartmentRequestModel();
                        model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiDepartmentResponseModel> result = await this.Client.DepartmentCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.DepartmentDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>e6be2e8160b87595bede6881855a8e61</Hash>
</Codenesium>*/