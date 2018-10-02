using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLSaleTicketMapper
	{
		BOSaleTicket MapModelToBO(
			int id,
			ApiSaleTicketRequestModel model);

		ApiSaleTicketResponseModel MapBOToModel(
			BOSaleTicket boSaleTicket);

		List<ApiSaleTicketResponseModel> MapBOToModel(
			List<BOSaleTicket> items);
	}
}

/*<Codenesium>
    <Hash>3cfe9c3305bb0af1272702691e2bc8f8</Hash>
</Codenesium>*/