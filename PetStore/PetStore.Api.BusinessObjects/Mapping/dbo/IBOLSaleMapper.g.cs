using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOLSaleMapper
	{
		DTOSale MapModelToDTO(
			int id,
			ApiSaleRequestModel model);

		ApiSaleResponseModel MapDTOToModel(
			DTOSale dtoSale);

		List<ApiSaleResponseModel> MapDTOToModel(
			List<DTOSale> dtos);
	}
}

/*<Codenesium>
    <Hash>94b6db81f08f0c24d0799c0b45722144</Hash>
</Codenesium>*/