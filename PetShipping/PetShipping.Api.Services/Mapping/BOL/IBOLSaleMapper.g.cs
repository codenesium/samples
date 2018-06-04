using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
			List<BOSale> bos);
	}
}

/*<Codenesium>
    <Hash>394d423e4e147d9f03a59c0200db0133</Hash>
</Codenesium>*/