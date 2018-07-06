using FileServiceNS.Api.Client;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "Integration")]
        public class VersionInfoIntegrationTests : IClassFixture<WebApplicationTestFixture<TestStartup>>
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
    <Hash>ffc896dbfbad34ccd06fbbdc3e08df00</Hash>
</Codenesium>*/