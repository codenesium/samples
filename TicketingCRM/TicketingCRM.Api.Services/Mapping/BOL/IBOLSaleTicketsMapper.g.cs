using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLSaleTicketsMapper
	{
		BOSaleTickets MapModelToBO(
			int id,
			ApiSaleTicketsRequestModel model);

		ApiSaleTicketsResponseModel MapBOToModel(
			BOSaleTickets boSaleTickets);

		List<ApiSaleTicketsResponseModel> MapBOToModel(
			List<BOSaleTickets> items);
	}
}

/*<Codenesium>
    <Hash>42f7e9715c2a82a9f0f28f80dd8dc454</Hash>
</Codenesium>*/