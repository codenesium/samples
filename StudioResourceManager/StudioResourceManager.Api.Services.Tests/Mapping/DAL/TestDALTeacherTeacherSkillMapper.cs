using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "DALMapper")]
	public class TestDALTeacherTeacherSkillMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			var bo = new BOTeacherTeacherSkill();
			bo.SetProperties(1, 1);

			TeacherTeacherSkill response = mapper.MapBOToEF(bo);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			entity.SetProperties(1, 1);

			BOTeacherTeacherSkill response = mapper.MapEFToBO(entity);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			entity.SetProperties(1, 1);

			List<BOTeacherTeacherSkill> response = mapper.MapEFToBO(new List<TeacherTeacherSkill>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6797681c1d314525661ae1d81fa3d730</Hash>
</Codenesium>*/