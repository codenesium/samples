using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Worker")]
        [Trait("Area", "DALMapper")]
        public class TestDALWorkerActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALWorkerMapper();

                        var bo = new BOWorker();

                        bo.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A");

                        Worker response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALWorkerMapper();

                        Worker entity = new Worker();

                        entity.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A");

                        BOWorker  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALWorkerMapper();

                        Worker entity = new Worker();

                        entity.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A");

                        List<BOWorker> response = mapper.MapEFToBO(new List<Worker>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9594f6a54242e0df6a12c72247292401</Hash>
</Codenesium>*/