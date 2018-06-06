using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>f7c937dade0b02133136b9668db63dc1</Hash>
</Codenesium>*/