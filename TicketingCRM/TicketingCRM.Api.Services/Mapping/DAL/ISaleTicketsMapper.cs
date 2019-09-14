using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALSaleTicketsMapper
	{
		SaleTickets MapModelToEntity(
			int id,
			ApiSaleTicketsServerRequestModel model);

		ApiSaleTicketsServerResponseModel MapEntityToModel(
			SaleTickets item);

		List<ApiSaleTicketsServerResponseModel> MapEntityToModel(
			List<SaleTickets> items);
	}
}

/*<Codenesium>
    <Hash>6d68b55b96eefe8072e34d43124dd72f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/