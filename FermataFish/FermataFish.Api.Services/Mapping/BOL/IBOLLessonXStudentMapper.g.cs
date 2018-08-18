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
    <Hash>c1b66b5ffcaafcf0d1740df391c49933</Hash>
</Codenesium>*/