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
    <Hash>bbe72c29892b403b236d169c7ed1900d</Hash>
</Codenesium>*/