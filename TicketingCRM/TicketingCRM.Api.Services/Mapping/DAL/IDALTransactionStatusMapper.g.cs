using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTransactionStatusMapper
	{
		TransactionStatus MapBOToEF(
			BOTransactionStatus bo);

		BOTransactionStatus MapEFToBO(
			TransactionStatus efTransactionStatus);

		List<BOTransactionStatus> MapEFToBO(
			List<TransactionStatus> records);
	}
}

/*<Codenesium>
    <Hash>2a0d5426a1757d3c382848c2e3ee4910</Hash>
</Codenesium>*/