using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Ticket")]
        [Trait("Area", "Integration")]
        public class TicketIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public TicketIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiTicketModelMapper mapper = new ApiTicketModelMapper();

                        UpdateResponse<ApiTicketResponseModel> updateResponse = await this.Client.TicketUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.TicketDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiTicketResponseModel response = await this.Client.TicketGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiTicketResponseModel> response = await this.Client.TicketAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiTicketResponseModel> CreateRecord()
                {
                        var model = new ApiTicketRequestModel();
                        model.SetProperties("B", 1);
                        CreateResponse<ApiTicketResponseModel> result = await this.Client.TicketCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.TicketDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>49dff1bb43cd4b8b7426c3c024dbb9c4</Hash>
</Codenesium>*/