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
			List<BOLessonStatus> bos);
	}
}

/*<Codenesium>
    <Hash>33f9574899226147a1ac132e06c3f5ec</Hash>
</Codenesium>*/