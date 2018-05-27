using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLOrganizationMapper
	{
		DTOOrganization MapModelToDTO(
			int id,
			ApiOrganizationRequestModel model);

		ApiOrganizationResponseModel MapDTOToModel(
			DTOOrganization dtoOrganization);

		List<ApiOrganizationResponseModel> MapDTOToModel(
			List<DTOOrganization> dtos);
	}
}

/*<Codenesium>
    <Hash>e805a9f14700cd1ef7d1ee2d9ca951bd</Hash>
</Codenesium>*/