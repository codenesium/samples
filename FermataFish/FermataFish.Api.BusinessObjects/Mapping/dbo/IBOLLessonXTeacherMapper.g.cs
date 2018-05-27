using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLLessonXTeacherMapper
	{
		DTOLessonXTeacher MapModelToDTO(
			int id,
			ApiLessonXTeacherRequestModel model);

		ApiLessonXTeacherResponseModel MapDTOToModel(
			DTOLessonXTeacher dtoLessonXTeacher);

		List<ApiLessonXTeacherResponseModel> MapDTOToModel(
			List<DTOLessonXTeacher> dtos);
	}
}

/*<Codenesium>
    <Hash>964bd953aaf41d4c3874e814386cdba6</Hash>
</Codenesium>*/