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
			List<BOLessonXTeacher> items);
	}
}

/*<Codenesium>
    <Hash>34b5d97d4e5d556de53f5bfff504eb7f</Hash>
</Codenesium>*/