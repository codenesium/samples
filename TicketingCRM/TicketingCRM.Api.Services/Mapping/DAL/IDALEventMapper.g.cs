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
    <Hash>ddf8ffe2a856827bb36ad7cc8c125e91</Hash>
</Codenesium>*/