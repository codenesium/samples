using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLSaleMapper
	{
		BOSale MapModelToBO(
			int id,
			ApiSaleServerRequestModel model);

		ApiSaleServerResponseModel MapBOToModel(
			BOSale boSale);

		List<ApiSaleServerResponseModel> MapBOToModel(
			List<BOSale> items);
	}
}

/*<Codenesium>
    <Hash>57c4e08291678459ccf185e8b65830cf</Hash>
</Codenesium>*/