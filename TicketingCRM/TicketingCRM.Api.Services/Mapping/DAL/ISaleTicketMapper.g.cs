using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALSaleTicketMapper
	{
		SaleTicket MapModelToEntity(
			int id,
			ApiSaleTicketServerRequestModel model);

		ApiSaleTicketServerResponseModel MapEntityToModel(
			SaleTicket item);

		List<ApiSaleTicketServerResponseModel> MapEntityToModel(
			List<SaleTicket> items);
	}
}

/*<Codenesium>
    <Hash>08d08673de98d4109f7d4a0085d66556</Hash>
</Codenesium>*/