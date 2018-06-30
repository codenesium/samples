using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "DALMapper")]
        public class TestDALWorkerTaskLeaseMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALWorkerTaskLeaseMapper();
                        var bo = new BOWorkerTaskLease();
                        bo.SetProperties("A", true, "A", "A", "A", "A");

                        WorkerTaskLease response = mapper.MapBOToEF(bo);

                        response.Exclusive.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.WorkerId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALWorkerTaskLeaseMapper();
                        WorkerTaskLease entity = new WorkerTaskLease();
                        entity.SetProperties(true, "A", "A", "A", "A", "A");

                        BOWorkerTaskLease response = mapper.MapEFToBO(entity);

                        response.Exclusive.Should().Be(true);
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TaskId.Should().Be("A");
                        response.WorkerId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALWorkerTaskLeaseMapper();
                        WorkerTaskLease entity = new WorkerTaskLease();
                        entity.SetProperties(true, "A", "A", "A", "A", "A");

                        List<BOWorkerTaskLease> response = mapper.MapEFToBO(new List<WorkerTaskLease>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>00356b37513c0fd91c5522ed4ee1090b</Hash>
</Codenesium>*/