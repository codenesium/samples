using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Event")]
        [Trait("Area", "ApiModel")]
        public class TestApiEventModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiEventModelMapper();
                        var model = new ApiEventRequestModel();
                        model.SetProperties(1, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
                        ApiEventResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.AutoId.Should().Be(1);
                        response.Category.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Message.Should().Be("A");
                        response.Occurred.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.UserId.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiEventModelMapper();
                        var model = new ApiEventResponseModel();
                        model.SetProperties("A", 1, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
                        ApiEventRequestModel response = mapper.MapResponseToRequest(model);

                        response.AutoId.Should().Be(1);
                        response.Category.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Message.Should().Be("A");
                        response.Occurred.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.UserId.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiEventModelMapper();
                        var model = new ApiEventRequestModel();
                        model.SetProperties(1, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");

                        JsonPatchDocument<ApiEventRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiEventRequestModel();
                        patch.ApplyTo(response);

                        response.AutoId.Should().Be(1);
                        response.Category.Should().Be("A");
                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Message.Should().Be("A");
                        response.Occurred.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.UserId.Should().Be("A");
                        response.Username.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>ea0b1413db5cb02b902ac581777d031b</Hash>
</Codenesium>*/