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
    <Hash>08b3355a7bb7088151dade61c38ddb63</Hash>
</Codenesium>*/