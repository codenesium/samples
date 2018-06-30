using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Interruption")]
        [Trait("Area", "ApiModel")]
        public class TestApiInterruptionModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiInterruptionModelMapper();
                        var model = new ApiInterruptionRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiInterruptionResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.ResponsibleTeamIds.Should().Be("A");
                        response.Status.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.Title.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiInterruptionModelMapper();
                        var model = new ApiInterruptionResponseModel();
                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiInterruptionRequestModel response = mapper.MapResponseToRequest(model);

                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.ResponsibleTeamIds.Should().Be("A");
                        response.Status.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.Title.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>4dc5b6fe0a3fa5897d881fd1b1c73663</Hash>
</Codenesium>*/