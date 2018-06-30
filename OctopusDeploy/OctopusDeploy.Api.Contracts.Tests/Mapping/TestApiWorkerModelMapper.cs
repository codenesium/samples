using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Worker")]
        [Trait("Area", "ApiModel")]
        public class TestApiWorkerModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiWorkerModelMapper();
                        var model = new ApiWorkerRequestModel();
                        model.SetProperties("A", "A", true, "A", "A", "A", "A", "A", "A");
                        ApiWorkerResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.CommunicationStyle.Should().Be("A");
                        response.Fingerprint.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.MachinePolicyId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                        response.WorkerPoolIds.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiWorkerModelMapper();
                        var model = new ApiWorkerResponseModel();
                        model.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A");
                        ApiWorkerRequestModel response = mapper.MapResponseToRequest(model);

                        response.CommunicationStyle.Should().Be("A");
                        response.Fingerprint.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.MachinePolicyId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                        response.WorkerPoolIds.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>73fc8bc382893809c4b41b9b85c944d4</Hash>
</Codenesium>*/