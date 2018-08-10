using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALEventMapper
	{
		Event MapBOToEF(
			BOEvent bo);

		BOEvent MapEFToBO(
			Event efEvent);

		List<BOEvent> MapEFToBO(
			List<Event> records);
	}
}

/*<Codenesium>
    <Hash>b97bb22de7f630b4bb92a5190bef233e</Hash>
</Codenesium>*/