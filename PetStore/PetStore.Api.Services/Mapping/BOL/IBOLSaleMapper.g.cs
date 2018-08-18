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
			ApiSaleRequestModel model);

		ApiSaleResponseModel MapBOToModel(
			BOSale boSale);

		List<ApiSaleResponseModel> MapBOToModel(
			List<BOSale> items);
	}
}

/*<Codenesium>
    <Hash>ea9c9d27387db10bd805759d1f46fb4c</Hash>
</Codenesium>*/