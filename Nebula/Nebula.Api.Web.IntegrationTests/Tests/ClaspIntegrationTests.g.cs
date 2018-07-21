using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Clasp")]
        [Trait("Area", "Integration")]
        public class ClaspIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ClaspIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiClaspModelMapper mapper = new ApiClaspModelMapper();

                        UpdateResponse<ApiClaspResponseModel> updateResponse = await this.Client.ClaspUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ClaspDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiClaspResponseModel response = await this.Client.ClaspGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiClaspResponseModel> response = await this.Client.ClaspAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiClaspResponseModel> CreateRecord()
                {
                        var model = new ApiClaspRequestModel();
                        model.SetProperties(1, 1);
                        CreateResponse<ApiClaspResponseModel> result = await this.Client.ClaspCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ClaspDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>cc1924ec83746d2b96f2632be2ee0c69</Hash>
</Codenesium>*/