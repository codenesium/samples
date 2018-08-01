using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOLessonXTeacher> items);
	}
}

/*<Codenesium>
    <Hash>522be5158492882fc13ba609409a8534</Hash>
</Codenesium>*/