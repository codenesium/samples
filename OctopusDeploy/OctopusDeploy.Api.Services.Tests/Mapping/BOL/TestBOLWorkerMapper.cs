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
        [Trait("Table", "Worker")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLWorkerActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLWorkerMapper();

                        ApiWorkerRequestModel model = new ApiWorkerRequestModel();

                        model.SetProperties("A", "A", true, "A", "A", "A", "A", "A", "A");
                        BOWorker response = mapper.MapModelToBO("A", model);

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

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLWorkerMapper();

                        BOWorker bo = new BOWorker();

                        bo.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A");
                        ApiWorkerResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLWorkerMapper();

                        BOWorker bo = new BOWorker();

                        bo.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A");
                        List<ApiWorkerResponseModel> response = mapper.MapBOToModel(new List<BOWorker>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>18ccc5bd0d832ad52edd7a8619de0f66</Hash>
</Codenesium>*/