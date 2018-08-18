using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLLessonMapper
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
    <Hash>17d6db18bd5a6587113560012ad27f95</Hash>
</Codenesium>*/