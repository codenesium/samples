using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>f09102689f287b22af564f9943e06818</Hash>
</Codenesium>*/