using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FermataFishNS.Api.Client;

namespace FermataFishNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "SpaceXSpaceFeature")]
        [Trait("Area", "Integration")]
        public class SpaceXSpaceFeatureTests
        {
                private TestServer server;
                private ApiClient client;

                public SpaceXSpaceFeatureTests()
                {
                }

                [Fact]
                public async void TestCreate()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestUpdate()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestDelete()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestGetById()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestSearch()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }

                [Fact]
                public async void TestBulkInsert()
                {
                        // setup
                        this.server = new TestServer(new WebHostBuilder()
                                                     .UseStartup<TestStartup>());

                        this.client = new ApiClient(this.server.CreateClient());
                }
        }
}

/*<Codenesium>
    <Hash>f2ca83c25df520c1f9f2a93bc5fc95c3</Hash>
</Codenesium>*/