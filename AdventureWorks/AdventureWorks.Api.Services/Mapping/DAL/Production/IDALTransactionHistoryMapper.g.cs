using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALTransactionHistoryMapper
	{
		TransactionHistory MapBOToEF(
			BOTransactionHistory bo);

		BOTransactionHistory MapEFToBO(
			TransactionHistory efTransactionHistory);

		List<BOTransactionHistory> MapEFToBO(
			List<TransactionHistory> records);
	}
}

/*<Codenesium>
    <Hash>0d1443d3849c76cd3eb92a420aeb4005</Hash>
</Codenesium>*/