using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLSaleMapper
	{
		BOSale MapModelToBO(
			int id,
			ApiSaleRequestModel model);

		ApiSaleResponseModel MapBOToModel(
			BOSale boSale);

		List<ApiSaleResponseModel> MapBOToModel(
			List<BOSale> items);
	}
}

/*<Codenesium>
    <Hash>fe6c20c7a6af453109e10ce4ca40a626</Hash>
</Codenesium>*/