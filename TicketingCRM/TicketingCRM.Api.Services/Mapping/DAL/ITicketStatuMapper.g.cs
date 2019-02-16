using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTicketStatuMapper
	{
		TicketStatu MapModelToEntity(
			int id,
			ApiTicketStatuServerRequestModel model);

		ApiTicketStatuServerResponseModel MapEntityToModel(
			TicketStatu item);

		List<ApiTicketStatuServerResponseModel> MapEntityToModel(
			List<TicketStatu> items);
	}
}

/*<Codenesium>
    <Hash>d543bc2306927db3f87cab5dcaccf285</Hash>
</Codenesium>*/