using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Country")]
        [Trait("Area", "Integration")]
        public class CountryTests
        {
                private TestServer server;
                private ApiClient client;

                public CountryTests()
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
    <Hash>af75da26ea49ff3fb7e3e04dcf38d872</Hash>
</Codenesium>*/