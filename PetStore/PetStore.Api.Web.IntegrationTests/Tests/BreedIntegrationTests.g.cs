using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Breed")]
        [Trait("Area", "Integration")]
        public class BreedIntegrationTests
        {
                public BreedIntegrationTests()
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
    <Hash>1a2941c42b2558bb8fe4bda73579539c</Hash>
</Codenesium>*/