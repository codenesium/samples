using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "City")]
        [Trait("Area", "Integration")]
        public class CityIntegrationTests : IClassFixture<WebApplicationTestFixture<TestStartup>>
        {
                public MyApplicationFunctionalTests(WebApplicationTestFixture<TestStartup> fixture)
                {
                        this.Client = new ApiClient(fixture.Client);
                }

                public ApiClient Client { get; }

                [Fact]
                public async void TestCreate()
                {
                }

                [Fact]
                public async void TestUpdate()
                {
                }

                [Fact]
                public async void TestDelete()
                {
                }

                [Fact]
                public async void TestGet()
                {
                }

                [Fact]
                public async void TestAll()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0d9b0c3fd8b694c3817c5a8b47c963e5</Hash>
</Codenesium>*/