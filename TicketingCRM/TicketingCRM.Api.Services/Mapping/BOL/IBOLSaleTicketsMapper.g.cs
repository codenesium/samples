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
    <Hash>2717c73cd7e5057c0f0cea67dfd62777</Hash>
</Codenesium>*/