using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTicketStatusMapper
	{
		TicketStatus MapModelToEntity(
			int id,
			ApiTicketStatusServerRequestModel model);

		ApiTicketStatusServerResponseModel MapEntityToModel(
			TicketStatus item);

		List<ApiTicketStatusServerResponseModel> MapEntityToModel(
			List<TicketStatus> items);
	}
}

/*<Codenesium>
    <Hash>38df4a6be42edf8034ddb495c48b694a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/