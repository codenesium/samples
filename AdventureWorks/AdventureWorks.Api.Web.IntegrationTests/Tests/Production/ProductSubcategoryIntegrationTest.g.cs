using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using AdventureWorksNS.Api.Client;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
        [Trait("Integration", "ProductSubcategory")]
        public class ProductSubcategoryTests
        {
                private TestServer server;
                private ApiClient client;

                public ProductSubcategoryTests()
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
    <Hash>7e91546bfd7f8e2857c91eb558d00777</Hash>
</Codenesium>*/