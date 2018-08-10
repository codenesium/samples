using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTicketStatusMapper
	{
		BOTicketStatus MapModelToBO(
			int id,
			ApiTicketStatusRequestModel model);

		ApiTicketStatusResponseModel MapBOToModel(
			BOTicketStatus boTicketStatus);

		List<ApiTicketStatusResponseModel> MapBOToModel(
			List<BOTicketStatus> items);
	}
}

/*<Codenesium>
    <Hash>a8eab0c4cff1ccb80ce5daf2a16c7518</Hash>
</Codenesium>*/