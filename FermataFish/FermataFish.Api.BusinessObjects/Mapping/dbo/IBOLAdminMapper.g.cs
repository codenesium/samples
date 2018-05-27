using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLAdminMapper
	{
		DTOAdmin MapModelToDTO(
			int id,
			ApiAdminRequestModel model);

		ApiAdminResponseModel MapDTOToModel(
			DTOAdmin dtoAdmin);

		List<ApiAdminResponseModel> MapDTOToModel(
			List<DTOAdmin> dtos);
	}
}

/*<Codenesium>
    <Hash>7d59de9e32a60834aaa04a23bc4a575b</Hash>
</Codenesium>*/