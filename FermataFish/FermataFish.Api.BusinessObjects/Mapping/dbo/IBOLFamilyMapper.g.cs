using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLFamilyMapper
	{
		DTOFamily MapModelToDTO(
			int id,
			ApiFamilyRequestModel model);

		ApiFamilyResponseModel MapDTOToModel(
			DTOFamily dtoFamily);

		List<ApiFamilyResponseModel> MapDTOToModel(
			List<DTOFamily> dtos);
	}
}

/*<Codenesium>
    <Hash>3f4f83d6feb80e06fdda2a9b8f182663</Hash>
</Codenesium>*/