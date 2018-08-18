using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLLessonStatusMapper
	{
		BOLessonStatus MapModelToBO(
			int id,
			ApiLessonStatusRequestModel model);

		ApiLessonStatusResponseModel MapBOToModel(
			BOLessonStatus boLessonStatus);

		List<ApiLessonStatusResponseModel> MapBOToModel(
			List<BOLessonStatus> items);
	}
}

/*<Codenesium>
    <Hash>6434b4299e16df330c79778f1a8b21c7</Hash>
</Codenesium>*/