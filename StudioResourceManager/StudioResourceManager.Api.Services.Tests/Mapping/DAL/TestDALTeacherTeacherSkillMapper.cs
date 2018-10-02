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
			bo.SetProperties(1, 1, 1);

			TeacherTeacherSkill response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			entity.SetProperties(1, 1, 1);

			BOTeacherTeacherSkill response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill entity = new TeacherTeacherSkill();
			entity.SetProperties(1, 1, 1);

			List<BOTeacherTeacherSkill> response = mapper.MapEFToBO(new List<TeacherTeacherSkill>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1aae6b002366e76cf0a5093c51150867</Hash>
</Codenesium>*/