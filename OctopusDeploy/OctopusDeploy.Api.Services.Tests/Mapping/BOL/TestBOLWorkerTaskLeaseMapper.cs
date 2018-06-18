using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLWorkerTaskLeaseActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLWorkerTaskLeaseMapper();

                        ApiWorkerTaskLeaseRequestModel model = new ApiWorkerTaskLeaseRequestModel();

                        model.SetProperties(true, "A", "A", "A", "A");
                        BOWorkerTaskLease response = mapper.MapModelToBO("A", model);

                        response.Exclusive.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.WorkerId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLWorkerTaskLeaseMapper();

                        BOWorkerTaskLease bo = new BOWorkerTaskLease();

                        bo.SetProperties("A", true, "A", "A", "A", "A");
                        ApiWorkerTaskLeaseResponseModel response = mapper.MapBOToModel(bo);

                        response.Exclusive.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.WorkerId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLWorkerTaskLeaseMapper();

                        BOWorkerTaskLease bo = new BOWorkerTaskLease();

                        bo.SetProperties("A", true, "A", "A", "A", "A");
                        List<ApiWorkerTaskLeaseResponseModel> response = mapper.MapBOToModel(new List<BOWorkerTaskLease>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1a037a3ae741d3bf223792cb3b72afa6</Hash>
</Codenesium>*/