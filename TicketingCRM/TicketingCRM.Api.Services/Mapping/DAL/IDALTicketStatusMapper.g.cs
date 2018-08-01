using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALTicketStatusMapper
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
    <Hash>b62ccbb25722221e98c9648954f15690</Hash>
</Codenesium>*/