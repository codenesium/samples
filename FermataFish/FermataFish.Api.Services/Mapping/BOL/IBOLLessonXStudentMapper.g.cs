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
			List<BOLessonXStudent> bos);
	}
}

/*<Codenesium>
    <Hash>908410148688681ef0e79c0b80e321cb</Hash>
</Codenesium>*/