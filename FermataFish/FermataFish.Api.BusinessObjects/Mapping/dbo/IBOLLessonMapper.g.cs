using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLLessonMapper
	{
		DTOLesson MapModelToDTO(
			int id,
			ApiLessonRequestModel model);

		ApiLessonResponseModel MapDTOToModel(
			DTOLesson dtoLesson);

		List<ApiLessonResponseModel> MapDTOToModel(
			List<DTOLesson> dtos);
	}
}

/*<Codenesium>
    <Hash>aecc55f8d618ad466496d006324df413</Hash>
</Codenesium>*/