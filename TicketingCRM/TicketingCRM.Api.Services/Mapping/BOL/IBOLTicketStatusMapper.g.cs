using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLTicketStatusMapper
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
    <Hash>27bb5d167922f3c367f823770934dd05</Hash>
</Codenesium>*/