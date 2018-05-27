using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLTeacherMapper
	{
		DTOTeacher MapModelToDTO(
			int id,
			ApiTeacherRequestModel model);

		ApiTeacherResponseModel MapDTOToModel(
			DTOTeacher dtoTeacher);

		List<ApiTeacherResponseModel> MapDTOToModel(
			List<DTOTeacher> dtos);
	}
}

/*<Codenesium>
    <Hash>ddba8e86bdacd8ef9479546beb2ce957</Hash>
</Codenesium>*/