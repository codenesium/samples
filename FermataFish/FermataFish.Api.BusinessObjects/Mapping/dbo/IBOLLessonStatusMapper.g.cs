using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLLessonStatusMapper
	{
		DTOLessonStatus MapModelToDTO(
			int id,
			ApiLessonStatusRequestModel model);

		ApiLessonStatusResponseModel MapDTOToModel(
			DTOLessonStatus dtoLessonStatus);

		List<ApiLessonStatusResponseModel> MapDTOToModel(
			List<DTOLessonStatus> dtos);
	}
}

/*<Codenesium>
    <Hash>34733f781a14363a0ffe08e9f6de92d6</Hash>
</Codenesium>*/