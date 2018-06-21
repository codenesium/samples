using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerPool")]
        [Trait("Area", "DALMapper")]
        public class TestDALWorkerPoolMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALWorkerPoolMapper();
                        var bo = new BOWorkerPool();
                        bo.SetProperties("A", true, "A", "A", 1);

                        WorkerPool response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALWorkerPoolMapper();
                        WorkerPool entity = new WorkerPool();
                        entity.SetProperties("A", true, "A", "A", 1);

                        BOWorkerPool response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALWorkerPoolMapper();
                        WorkerPool entity = new WorkerPool();
                        entity.SetProperties("A", true, "A", "A", 1);

                        List<BOWorkerPool> response = mapper.MapEFToBO(new List<WorkerPool>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>97a62b4a7094ddd74567ba3fa07a1d45</Hash>
</Codenesium>*/