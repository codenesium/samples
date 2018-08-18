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
    <Hash>034e81774c563d5eed809564a776c006</Hash>
</Codenesium>*/