using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLStudentMapper
	{
		DTOStudent MapModelToDTO(
			int id,
			ApiStudentRequestModel model);

		ApiStudentResponseModel MapDTOToModel(
			DTOStudent dtoStudent);

		List<ApiStudentResponseModel> MapDTOToModel(
			List<DTOStudent> dtos);
	}
}

/*<Codenesium>
    <Hash>71e1e80701acf231d3e7b0c631adbfa0</Hash>
</Codenesium>*/