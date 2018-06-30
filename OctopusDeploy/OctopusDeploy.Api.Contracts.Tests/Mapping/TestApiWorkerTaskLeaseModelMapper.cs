using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "ApiModel")]
        public class TestApiWorkerTaskLeaseModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiWorkerTaskLeaseModelMapper();
                        var model = new ApiWorkerTaskLeaseRequestModel();
                        model.SetProperties(true, "A", "A", "A", "A");
                        ApiWorkerTaskLeaseResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Exclusive.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.WorkerId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiWorkerTaskLeaseModelMapper();
                        var model = new ApiWorkerTaskLeaseResponseModel();
                        model.SetProperties("A", true, "A", "A", "A", "A");
                        ApiWorkerTaskLeaseRequestModel response = mapper.MapResponseToRequest(model);

                        response.Exclusive.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.WorkerId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>29de5d6334fc5fd1aee895d93fa5c9a4</Hash>
</Codenesium>*/