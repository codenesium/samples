using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "ProductReview")]
        [Trait("Area", "Integration")]
        public class ProductReviewIntegrationTests
        {
                public ProductReviewIntegrationTests()
                {
                }

                [Fact]
                public async void TestCreate()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestUpdate()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestDelete()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestGet()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestAll()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                }
        }
}

/*<Codenesium>
    <Hash>ca05d5d0cb49c18d9322fbd706eb19ee</Hash>
</Codenesium>*/