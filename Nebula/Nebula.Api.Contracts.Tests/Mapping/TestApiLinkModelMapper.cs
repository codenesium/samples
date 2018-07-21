using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Link")]
        [Trait("Area", "ApiModel")]
        public class TestApiLinkModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLinkModelMapper();
                        var model = new ApiLinkRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
                        ApiLinkResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AssignedMachineId.Should().Be(1);
                        response.ChainId.Should().Be(1);
                        response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DynamicParameters.Should().Be("A");
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be(1);
                        response.LinkStatusId.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Order.Should().Be(1);
                        response.Response.Should().Be("A");
                        response.StaticParameters.Should().Be("A");
                        response.TimeoutInSeconds.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLinkModelMapper();
                        var model = new ApiLinkResponseModel();
                        model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
                        ApiLinkRequestModel response = mapper.MapResponseToRequest(model);

                        response.AssignedMachineId.Should().Be(1);
                        response.ChainId.Should().Be(1);
                        response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DynamicParameters.Should().Be("A");
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.LinkStatusId.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Order.Should().Be(1);
                        response.Response.Should().Be("A");
                        response.StaticParameters.Should().Be("A");
                        response.TimeoutInSeconds.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiLinkModelMapper();
                        var model = new ApiLinkRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);

                        JsonPatchDocument<ApiLinkRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiLinkRequestModel();
                        patch.ApplyTo(response);

                        response.AssignedMachineId.Should().Be(1);
                        response.ChainId.Should().Be(1);
                        response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.DynamicParameters.Should().Be("A");
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.LinkStatusId.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.Order.Should().Be(1);
                        response.Response.Should().Be("A");
                        response.StaticParameters.Should().Be("A");
                        response.TimeoutInSeconds.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b02623906d71fe475caa3ab3396cca00</Hash>
</Codenesium>*/