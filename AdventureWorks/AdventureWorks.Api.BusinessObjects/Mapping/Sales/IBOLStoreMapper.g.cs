using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLStoreMapper
	{
		DTOStore MapModelToDTO(
			int businessEntityID,
			ApiStoreRequestModel model);

		ApiStoreResponseModel MapDTOToModel(
			DTOStore dtoStore);

		List<ApiStoreResponseModel> MapDTOToModel(
			List<DTOStore> dtos);
	}
}

/*<Codenesium>
    <Hash>a45dc24bc38b6142a3926f90f8476f6d</Hash>
</Codenesium>*/