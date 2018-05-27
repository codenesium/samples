using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLLessonXStudentMapper
	{
		DTOLessonXStudent MapModelToDTO(
			int id,
			ApiLessonXStudentRequestModel model);

		ApiLessonXStudentResponseModel MapDTOToModel(
			DTOLessonXStudent dtoLessonXStudent);

		List<ApiLessonXStudentResponseModel> MapDTOToModel(
			List<DTOLessonXStudent> dtos);
	}
}

/*<Codenesium>
    <Hash>5f81e6cae68532d854230761f160f1c0</Hash>
</Codenesium>*/