using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
    <Hash>ff2709024912de40964bfee74a46ebc9</Hash>
</Codenesium>*/