using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LessonXTeacher")]
	[Trait("Area", "DALMapper")]
	public class TestDALLessonXTeacherMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLessonXTeacherMapper();
			var bo = new BOLessonXTeacher();
			bo.SetProperties(1, 1, 1);

			LessonXTeacher response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLessonXTeacherMapper();
			LessonXTeacher entity = new LessonXTeacher();
			entity.SetProperties(1, 1, 1);

			BOLessonXTeacher response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLessonXTeacherMapper();
			LessonXTeacher entity = new LessonXTeacher();
			entity.SetProperties(1, 1, 1);

			List<BOLessonXTeacher> response = mapper.MapEFToBO(new List<LessonXTeacher>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7ee701067d9e22c185f1c54e44f31895</Hash>
</Codenesium>*/