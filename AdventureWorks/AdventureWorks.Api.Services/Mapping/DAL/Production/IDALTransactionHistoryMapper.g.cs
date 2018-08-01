using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>6049cb2809cda8afd5d9cefac0797c61</Hash>
</Codenesium>*/