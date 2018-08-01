using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLSaleTicketsMapper
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
    <Hash>53bd220804113b39aedef0c6d2ae0df2</Hash>
</Codenesium>*/