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
    <Hash>b853a527430d1830f0b29f3edc2771a1</Hash>
</Codenesium>*/