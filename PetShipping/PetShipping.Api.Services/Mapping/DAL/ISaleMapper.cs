using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALSaleMapper
	{
		Sale MapModelToEntity(
			int id,
			ApiSaleServerRequestModel model);

		ApiSaleServerResponseModel MapEntityToModel(
			Sale item);

		List<ApiSaleServerResponseModel> MapEntityToModel(
			List<Sale> items);
	}
}

/*<Codenesium>
    <Hash>1f50a6620d847db64549b6f3d55bfe6e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/