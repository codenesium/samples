using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLLessonXStudentMapper
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
    <Hash>93f11b1760dc5001a4964fe1bffadd4f</Hash>
</Codenesium>*/