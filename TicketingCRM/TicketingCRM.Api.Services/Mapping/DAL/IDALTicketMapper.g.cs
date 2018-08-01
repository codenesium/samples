using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALTicketMapper
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
    <Hash>a7c0bfc0ca690281538545b81f6954c7</Hash>
</Codenesium>*/