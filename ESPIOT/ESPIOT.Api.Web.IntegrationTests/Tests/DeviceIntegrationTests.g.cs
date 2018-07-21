using ESPIOTNS.Api.Client;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ESPIOTNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Device")]
        [Trait("Area", "Integration")]
        public class DeviceIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public DeviceIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiDeviceModelMapper mapper = new ApiDeviceModelMapper();

                        UpdateResponse<ApiDeviceResponseModel> updateResponse = await this.Client.DeviceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.DeviceDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiDeviceResponseModel response = await this.Client.DeviceGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiDeviceResponseModel> response = await this.Client.DeviceAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiDeviceResponseModel> CreateRecord()
                {
                        var model = new ApiDeviceRequestModel();
                        model.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
                        CreateResponse<ApiDeviceResponseModel> result = await this.Client.DeviceCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.DeviceDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>8cf9ddcb12f1db995035796d9276842b</Hash>
</Codenesium>*/