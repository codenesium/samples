using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTicketMapper
	{
		Ticket MapBOToEF(
			BOTicket bo);

		BOTicket MapEFToBO(
			Ticket efTicket);

		List<BOTicket> MapEFToBO(
			List<Ticket> records);
	}
}

/*<Codenesium>
    <Hash>984d2eb6da377efe6a9c8b44e0d1a12a</Hash>
</Codenesium>*/