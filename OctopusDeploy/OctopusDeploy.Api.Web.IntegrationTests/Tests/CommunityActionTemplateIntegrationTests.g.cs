using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "CommunityActionTemplate")]
        [Trait("Area", "Integration")]
        public class CommunityActionTemplateIntegrationTests
        {
                public CommunityActionTemplateIntegrationTests()
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
    <Hash>65f20ea03fd27e677e5b91db136b6ee3</Hash>
</Codenesium>*/