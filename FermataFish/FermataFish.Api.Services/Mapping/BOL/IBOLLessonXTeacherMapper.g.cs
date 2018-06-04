using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLLessonXTeacherMapper
	{
		BOLessonXTeacher MapModelToBO(
			int id,
			ApiLessonXTeacherRequestModel model);

		ApiLessonXTeacherResponseModel MapBOToModel(
			BOLessonXTeacher boLessonXTeacher);

		List<ApiLessonXTeacherResponseModel> MapBOToModel(
			List<BOLessonXTeacher> bos);
	}
}

/*<Codenesium>
    <Hash>5a103afbc98f0f00957a59cc72dcfc62</Hash>
</Codenesium>*/