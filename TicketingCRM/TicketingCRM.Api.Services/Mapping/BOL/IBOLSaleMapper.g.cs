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
			ApiSaleServerRequestModel model);

		ApiSaleServerResponseModel MapBOToModel(
			BOSale boSale);

		List<ApiSaleServerResponseModel> MapBOToModel(
			List<BOSale> items);
	}
}

/*<Codenesium>
    <Hash>4e971e40ccef5298ac7802f9e0d67919</Hash>
</Codenesium>*/