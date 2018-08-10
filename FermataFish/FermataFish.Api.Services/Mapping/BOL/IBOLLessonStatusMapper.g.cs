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
    <Hash>dbd12142d5dcdf8f3bf6734ef7a3d83d</Hash>
</Codenesium>*/