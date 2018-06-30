using FluentAssertions;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Machine")]
        [Trait("Area", "ApiModel")]
        public class TestApiMachineModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiMachineModelMapper();
                        var model = new ApiMachineRequestModel();
                        model.SetProperties("A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        ApiMachineResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.JwtKey.Should().Be("A");
                        response.LastIpAddress.Should().Be("A");
                        response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiMachineModelMapper();
                        var model = new ApiMachineResponseModel();
                        model.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        ApiMachineRequestModel response = mapper.MapResponseToRequest(model);

                        response.Description.Should().Be("A");
                        response.JwtKey.Should().Be("A");
                        response.LastIpAddress.Should().Be("A");
                        response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>7cf78ce0bc7500858b9a9c2fd78559f4</Hash>
</Codenesium>*/