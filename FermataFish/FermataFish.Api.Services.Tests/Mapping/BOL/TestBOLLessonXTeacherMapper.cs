using FermataFishNS.Api.Contracts;
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
	[Trait("Area", "BOLMapper")]
	public class TestBOLLessonXTeacherMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLessonXTeacherMapper();
			ApiLessonXTeacherRequestModel model = new ApiLessonXTeacherRequestModel();
			model.SetProperties(1, 1);
			BOLessonXTeacher response = mapper.MapModelToBO(1, model);

			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLessonXTeacherMapper();
			BOLessonXTeacher bo = new BOLessonXTeacher();
			bo.SetProperties(1, 1, 1);
			ApiLessonXTeacherResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.LessonId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLessonXTeacherMapper();
			BOLessonXTeacher bo = new BOLessonXTeacher();
			bo.SetProperties(1, 1, 1);
			List<ApiLessonXTeacherResponseModel> response = mapper.MapBOToModel(new List<BOLessonXTeacher>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2f6379b3ac5e782af91311d7f68e98e5</Hash>
</Codenesium>*/