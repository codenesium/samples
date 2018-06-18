using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TeacherXTeacherSkill")]
        [Trait("Area", "DALMapper")]
        public class TestDALTeacherXTeacherSkillActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTeacherXTeacherSkillMapper();

                        var bo = new BOTeacherXTeacherSkill();

                        bo.SetProperties(1, 1, 1);

                        TeacherXTeacherSkill response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALTeacherXTeacherSkillMapper();

                        TeacherXTeacherSkill entity = new TeacherXTeacherSkill();

                        entity.SetProperties(1, 1, 1);

                        BOTeacherXTeacherSkill  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALTeacherXTeacherSkillMapper();

                        TeacherXTeacherSkill entity = new TeacherXTeacherSkill();

                        entity.SetProperties(1, 1, 1);

                        List<BOTeacherXTeacherSkill> response = mapper.MapEFToBO(new List<TeacherXTeacherSkill>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5e4e0f50c8d2d9e9190a72aab302c878</Hash>
</Codenesium>*/