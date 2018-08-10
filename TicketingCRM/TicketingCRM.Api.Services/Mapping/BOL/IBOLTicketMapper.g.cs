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
    <Hash>19bee792ce02a7161babee38dd76815f</Hash>
</Codenesium>*/