using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTransactionStatuMapper
	{
		TransactionStatu MapBOToEF(
			BOTransactionStatu bo);

		BOTransactionStatu MapEFToBO(
			TransactionStatu efTransactionStatu);

		List<BOTransactionStatu> MapEFToBO(
			List<TransactionStatu> records);
	}
}

/*<Codenesium>
    <Hash>a621ac8233d3abfc10ed34b3a266258b</Hash>
</Codenesium>*/