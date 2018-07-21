using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Document")]
        [Trait("Area", "Integration")]
        public class DocumentIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public DocumentIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiDocumentModelMapper mapper = new ApiDocumentModelMapper();

                        UpdateResponse<ApiDocumentResponseModel> updateResponse = await this.Client.DocumentUpdateAsync(model.Rowguid, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.DocumentDeleteAsync(model.Rowguid);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiDocumentResponseModel response = await this.Client.DocumentGetAsync(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiDocumentResponseModel> response = await this.Client.DocumentAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiDocumentResponseModel> CreateRecord()
                {
                        var model = new ApiDocumentRequestModel();
                        model.SetProperties(2, BitConverter.GetBytes(2), 2, "B", "B", "B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, "B", 2, "B");
                        CreateResponse<ApiDocumentResponseModel> result = await this.Client.DocumentCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.DocumentDeleteAsync(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
                }
        }
}

/*<Codenesium>
    <Hash>3b456c73e8dfdb55ce1c122389a20d8d</Hash>
</Codenesium>*/