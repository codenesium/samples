using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
			List<BOLesson> bos);
	}
}

/*<Codenesium>
    <Hash>57a2fa2d2ee42b0709c954a0be746e65</Hash>
</Codenesium>*/