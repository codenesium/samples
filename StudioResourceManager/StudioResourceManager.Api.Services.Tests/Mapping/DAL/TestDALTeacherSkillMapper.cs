using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "DALMapper")]
	public class TestDALTeacherSkillMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTeacherSkillMapper();
			var bo = new BOTeacherSkill();
			bo.SetProperties(1, "A", true);

			TeacherSkill response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTeacherSkillMapper();
			TeacherSkill entity = new TeacherSkill();
			entity.SetProperties(1, "A", true);

			BOTeacherSkill response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTeacherSkillMapper();
			TeacherSkill entity = new TeacherSkill();
			entity.SetProperties(1, "A", true);

			List<BOTeacherSkill> response = mapper.MapEFToBO(new List<TeacherSkill>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fd27ed2d15884ce6eb1bc181706aa4bc</Hash>
</Codenesium>*/