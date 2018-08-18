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
    <Hash>40712a370cf7f3caf147ab29a5ef9494</Hash>
</Codenesium>*/