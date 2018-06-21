using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "JobCandidate")]
        [Trait("Area", "DALMapper")]
        public class TestDALJobCandidateMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALJobCandidateMapper();
                        var bo = new BOJobCandidate();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        JobCandidate response = mapper.MapBOToEF(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.JobCandidateID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Resume.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALJobCandidateMapper();
                        JobCandidate entity = new JobCandidate();
                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOJobCandidate response = mapper.MapEFToBO(entity);

                        response.BusinessEntityID.Should().Be(1);
                        response.JobCandidateID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Resume.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALJobCandidateMapper();
                        JobCandidate entity = new JobCandidate();
                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOJobCandidate> response = mapper.MapEFToBO(new List<JobCandidate>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e6f480c2e4fa87591c18b8983a70f2df</Hash>
</Codenesium>*/