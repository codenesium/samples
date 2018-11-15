using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
    <Hash>766eeb1a2562a07193b83e03141459e0</Hash>
</Codenesium>*/