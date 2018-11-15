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
			ApiTicketServerRequestModel model);

		ApiTicketServerResponseModel MapBOToModel(
			BOTicket boTicket);

		List<ApiTicketServerResponseModel> MapBOToModel(
			List<BOTicket> items);
	}
}

/*<Codenesium>
    <Hash>e98f634d7ffee5e01a89e184b3ecd9f6</Hash>
</Codenesium>*/