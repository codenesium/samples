using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALTransactionStatusMapper
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
    <Hash>ef1849bf7339c89c978b18f5ba961366</Hash>
</Codenesium>*/