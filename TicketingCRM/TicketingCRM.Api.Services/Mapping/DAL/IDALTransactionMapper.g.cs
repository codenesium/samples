using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALTransactionMapper
	{
		Transaction MapBOToEF(
			BOTransaction bo);

		BOTransaction MapEFToBO(
			Transaction efTransaction);

		List<BOTransaction> MapEFToBO(
			List<Transaction> records);
	}
}

/*<Codenesium>
    <Hash>5cc7cf324afae787dc41d0c4bd1bf11a</Hash>
</Codenesium>*/