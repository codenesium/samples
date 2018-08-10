using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLLessonXTeacherMapper
	{
		BOLessonXTeacher MapModelToBO(
			int id,
			ApiLessonXTeacherRequestModel model);

		ApiLessonXTeacherResponseModel MapBOToModel(
			BOLessonXTeacher boLessonXTeacher);

		List<ApiLessonXTeacherResponseModel> MapBOToModel(
			List<BOLessonXTeacher> items);
	}
}

/*<Codenesium>
    <Hash>f5f07a8ff26fcc866ec63ba16e39be03</Hash>
</Codenesium>*/