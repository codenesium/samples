using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTicketStatusMapper
	{
		TicketStatus MapBOToEF(
			BOTicketStatus bo);

		BOTicketStatus MapEFToBO(
			TicketStatus efTicketStatus);

		List<BOTicketStatus> MapEFToBO(
			List<TicketStatus> records);
	}
}

/*<Codenesium>
    <Hash>1def86d5ce83737592c48e07cfb20a4b</Hash>
</Codenesium>*/