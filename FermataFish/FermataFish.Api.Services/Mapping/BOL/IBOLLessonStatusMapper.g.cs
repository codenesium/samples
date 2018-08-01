using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLLessonStatusMapper
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
    <Hash>3b6ad9dc8d103d0d9a7b749456f68ab4</Hash>
</Codenesium>*/