using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "TimestampCheck")]
        [Trait("Area", "Integration")]
        public class TimestampCheckIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public TimestampCheckIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiTimestampCheckModelMapper mapper = new ApiTimestampCheckModelMapper();

                        UpdateResponse<ApiTimestampCheckResponseModel> updateResponse = await this.Client.TimestampCheckUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.TimestampCheckDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiTimestampCheckResponseModel response = await this.Client.TimestampCheckGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiTimestampCheckResponseModel> response = await this.Client.TimestampCheckAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiTimestampCheckResponseModel> CreateRecord()
                {
                        var model = new ApiTimestampCheckRequestModel();
                        model.SetProperties("B", BitConverter.GetBytes(2));
                        CreateResponse<ApiTimestampCheckResponseModel> result = await this.Client.TimestampCheckCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.TimestampCheckDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>a260d38007f0b3ef38212a2a6e40c13b</Hash>
</Codenesium>*/