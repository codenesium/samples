using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLLessonXStudentMapper
	{
		BOLessonXStudent MapModelToBO(
			int id,
			ApiLessonXStudentRequestModel model);

		ApiLessonXStudentResponseModel MapBOToModel(
			BOLessonXStudent boLessonXStudent);

		List<ApiLessonXStudentResponseModel> MapBOToModel(
			List<BOLessonXStudent> items);
	}
}

/*<Codenesium>
    <Hash>61a00e79d475c98b7cf7a098a92338d3</Hash>
</Codenesium>*/