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
			List<BOLesson> items);
	}
}

/*<Codenesium>
    <Hash>8559bfe44401279ea4aa306bd82eac59</Hash>
</Codenesium>*/