using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Species")]
        [Trait("Area", "Integration")]
        public class SpeciesIntegrationTests
        {
                public SpeciesIntegrationTests()
                {
                }

                [Fact]
                public async void TestCreate()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                        await Task.CompletedTask;
                }

                [Fact]
                public async void TestUpdate()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                        await Task.CompletedTask;
                }

                [Fact]
                public async void TestDelete()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                        await Task.CompletedTask;
                }

                [Fact]
                public async void TestGet()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        await Task.CompletedTask;
                        ApiClient client = new ApiClient(server.CreateClient());
                }

                [Fact]
                public async void TestAll()
                {
                        TestServer server = new TestServer(new WebHostBuilder()
                                                           .UseStartup<TestStartup>());
                        ApiClient client = new ApiClient(server.CreateClient());
                        await Task.CompletedTask;
                }
        }
}

/*<Codenesium>
    <Hash>d70b16c2b1504f302578f6d4ab963730</Hash>
</Codenesium>*/