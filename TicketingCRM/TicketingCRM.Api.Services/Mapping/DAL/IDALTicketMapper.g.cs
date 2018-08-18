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
    <Hash>c5331ba68d76099399f11be948cd6cfe</Hash>
</Codenesium>*/