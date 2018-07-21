using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Certificate")]
        [Trait("Area", "Integration")]
        public class CertificateIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public CertificateIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiCertificateModelMapper mapper = new ApiCertificateModelMapper();

                        UpdateResponse<ApiCertificateResponseModel> updateResponse = await this.Client.CertificateUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.CertificateDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiCertificateResponseModel response = await this.Client.CertificateGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiCertificateResponseModel> response = await this.Client.CertificateAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiCertificateResponseModel> CreateRecord()
                {
                        var model = new ApiCertificateRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), BitConverter.GetBytes(2), "B", "B", "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B");
                        CreateResponse<ApiCertificateResponseModel> result = await this.Client.CertificateCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.CertificateDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>17191d4d02197df76c231764959c5258</Hash>
</Codenesium>*/