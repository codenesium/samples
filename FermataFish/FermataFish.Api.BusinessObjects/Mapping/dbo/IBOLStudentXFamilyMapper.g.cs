using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLStudentXFamilyMapper
	{
		DTOStudentXFamily MapModelToDTO(
			int id,
			ApiStudentXFamilyRequestModel model);

		ApiStudentXFamilyResponseModel MapDTOToModel(
			DTOStudentXFamily dtoStudentXFamily);

		List<ApiStudentXFamilyResponseModel> MapDTOToModel(
			List<DTOStudentXFamily> dtos);
	}
}

/*<Codenesium>
    <Hash>d78d6b8bdf0af22435e25285d38fb9c7</Hash>
</Codenesium>*/