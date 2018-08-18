using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTicketMapper
	{
		BOTicket MapModelToBO(
			int id,
			ApiTicketRequestModel model);

		ApiTicketResponseModel MapBOToModel(
			BOTicket boTicket);

		List<ApiTicketResponseModel> MapBOToModel(
			List<BOTicket> items);
	}
}

/*<Codenesium>
    <Hash>1ee43cab1b96659865a71adc68b7a2a5</Hash>
</Codenesium>*/