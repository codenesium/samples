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
        [Trait("Table", "WorkerPool")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLWorkerPoolActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLWorkerPoolMapper();

                        ApiWorkerPoolRequestModel model = new ApiWorkerPoolRequestModel();

                        model.SetProperties(true, "A", "A", 1);
                        BOWorkerPool response = mapper.MapModelToBO("A", model);

                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLWorkerPoolMapper();

                        BOWorkerPool bo = new BOWorkerPool();

                        bo.SetProperties("A", true, "A", "A", 1);
                        ApiWorkerPoolResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLWorkerPoolMapper();

                        BOWorkerPool bo = new BOWorkerPool();

                        bo.SetProperties("A", true, "A", "A", 1);
                        List<ApiWorkerPoolResponseModel> response = mapper.MapBOToModel(new List<BOWorkerPool>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>dcf1a48d8b5224b2a7ee2db5ac3faae7</Hash>
</Codenesium>*/