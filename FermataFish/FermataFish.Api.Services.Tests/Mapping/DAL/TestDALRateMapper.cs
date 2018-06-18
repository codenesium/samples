using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Rate")]
        [Trait("Area", "DALMapper")]
        public class TestDALRateActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALRateMapper();

                        var bo = new BORate();

                        bo.SetProperties(1, 1, 1, 1);

                        Rate response = mapper.MapBOToEF(bo);

                        response.AmountPerMinute.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALRateMapper();

                        Rate entity = new Rate();

                        entity.SetProperties(1, 1, 1, 1);

                        BORate  response = mapper.MapEFToBO(entity);

                        response.AmountPerMinute.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALRateMapper();

                        Rate entity = new Rate();

                        entity.SetProperties(1, 1, 1, 1);

                        List<BORate> response = mapper.MapEFToBO(new List<Rate>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>481a9f0ce7db2dd05b41fb92ab3b51ed</Hash>
</Codenesium>*/