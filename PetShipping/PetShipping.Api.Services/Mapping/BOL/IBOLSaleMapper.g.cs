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
			ApiSaleRequestModel model);

		ApiSaleResponseModel MapBOToModel(
			BOSale boSale);

		List<ApiSaleResponseModel> MapBOToModel(
			List<BOSale> items);
	}
}

/*<Codenesium>
    <Hash>893050545a45b24b8adfadbc2af8c953</Hash>
</Codenesium>*/