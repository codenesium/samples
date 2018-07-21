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
        [Trait("Table", "Subscription")]
        [Trait("Area", "Integration")]
        public class SubscriptionIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public SubscriptionIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiSubscriptionModelMapper mapper = new ApiSubscriptionModelMapper();

                        UpdateResponse<ApiSubscriptionResponseModel> updateResponse = await this.Client.SubscriptionUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.SubscriptionDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiSubscriptionResponseModel response = await this.Client.SubscriptionGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiSubscriptionResponseModel> response = await this.Client.SubscriptionAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiSubscriptionResponseModel> CreateRecord()
                {
                        var model = new ApiSubscriptionRequestModel();
                        model.SetProperties(true, "B", "B", "B");
                        CreateResponse<ApiSubscriptionResponseModel> result = await this.Client.SubscriptionCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.SubscriptionDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>4087c7f8060291105d3b7dd2b2c59c2d</Hash>
</Codenesium>*/