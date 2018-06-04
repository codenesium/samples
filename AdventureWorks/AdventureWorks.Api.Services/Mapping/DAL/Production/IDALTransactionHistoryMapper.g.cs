using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALTransactionHistoryMapper
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
    <Hash>8c1eefa8480d90cde5d496c2b4e2e56e</Hash>
</Codenesium>*/