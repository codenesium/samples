using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLTicketMapper
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
    <Hash>fa726d55649f7adcdbce44e77607181b</Hash>
</Codenesium>*/