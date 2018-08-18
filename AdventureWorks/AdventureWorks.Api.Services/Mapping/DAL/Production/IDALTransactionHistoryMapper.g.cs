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
    <Hash>dabb14e2f1ee3a148fe277a66425db55</Hash>
</Codenesium>*/