using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Person")]
        [Trait("Area", "Integration")]
        public class PersonIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PersonIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPersonModelMapper mapper = new ApiPersonModelMapper();

                        UpdateResponse<ApiPersonResponseModel> updateResponse = await this.Client.PersonUpdateAsync(model.PersonId, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PersonDeleteAsync(model.PersonId);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPersonResponseModel response = await this.Client.PersonGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPersonResponseModel> response = await this.Client.PersonAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPersonResponseModel> CreateRecord()
                {
                        var model = new ApiPersonRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiPersonResponseModel> result = await this.Client.PersonCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PersonDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>54a26cf7e016b3c2eb0088ab60f522ac</Hash>
</Codenesium>*/