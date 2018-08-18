using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTransactionMapper
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
    <Hash>ffe55b6ccff5a48a6e2bd78bb277a0a5</Hash>
</Codenesium>*/