using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>59b3e72a5ddbf0fda6c5440dd0fcaa3b</Hash>
</Codenesium>*/