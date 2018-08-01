using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLLessonMapper
	{
		BOLesson MapModelToBO(
			int id,
			ApiLessonRequestModel model);

		ApiLessonResponseModel MapBOToModel(
			BOLesson boLesson);

		List<ApiLessonResponseModel> MapBOToModel(
			List<BOLesson> items);
	}
}

/*<Codenesium>
    <Hash>4319caa87b2766b299e0200d9f3687ee</Hash>
</Codenesium>*/