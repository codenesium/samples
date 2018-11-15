using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTicketStatuMapper
	{
		BOTicketStatu MapModelToBO(
			int id,
			ApiTicketStatuServerRequestModel model);

		ApiTicketStatuServerResponseModel MapBOToModel(
			BOTicketStatu boTicketStatu);

		List<ApiTicketStatuServerResponseModel> MapBOToModel(
			List<BOTicketStatu> items);
	}
}

/*<Codenesium>
    <Hash>7c62e8f88c8e41875d016787faab31ee</Hash>
</Codenesium>*/