using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTicketMapper
	{
		Ticket MapModelToEntity(
			int id,
			ApiTicketServerRequestModel model);

		ApiTicketServerResponseModel MapEntityToModel(
			Ticket item);

		List<ApiTicketServerResponseModel> MapEntityToModel(
			List<Ticket> items);
	}
}

/*<Codenesium>
    <Hash>b9e12a2a730fe9a4a762fed21e5a7fd7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/