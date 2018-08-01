using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
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
			bo.SetProperties(1, "A", 1);

			TeacherSkill response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTeacherSkillMapper();
			TeacherSkill entity = new TeacherSkill();
			entity.SetProperties(1, "A", 1);

			BOTeacherSkill response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTeacherSkillMapper();
			TeacherSkill entity = new TeacherSkill();
			entity.SetProperties(1, "A", 1);

			List<BOTeacherSkill> response = mapper.MapEFToBO(new List<TeacherSkill>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7a968b2c8556e955319020f8bda5a3ef</Hash>
</Codenesium>*/