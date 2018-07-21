using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Rate")]
        [Trait("Area", "DALMapper")]
        public class TestDALRateMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALRateMapper();
                        var bo = new BORate();
                        bo.SetProperties(1, 1m, 1, 1);

                        Rate response = mapper.MapBOToEF(bo);

                        response.AmountPerMinute.Should().Be(1m);
                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALRateMapper();
                        Rate entity = new Rate();
                        entity.SetProperties(1m, 1, 1, 1);

                        BORate response = mapper.MapEFToBO(entity);

                        response.AmountPerMinute.Should().Be(1m);
                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALRateMapper();
                        Rate entity = new Rate();
                        entity.SetProperties(1m, 1, 1, 1);

                        List<BORate> response = mapper.MapEFToBO(new List<Rate>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>165535fdc50a2684afc1b18de96498f7</Hash>
</Codenesium>*/