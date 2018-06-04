using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALTransactionHistoryArchiveMapper
	{
		TransactionHistoryArchive MapBOToEF(
			BOTransactionHistoryArchive bo);

		BOTransactionHistoryArchive MapEFToBO(
			TransactionHistoryArchive efTransactionHistoryArchive);

		List<BOTransactionHistoryArchive> MapEFToBO(
			List<TransactionHistoryArchive> records);
	}
}

/*<Codenesium>
    <Hash>21abaa30ee58b9b440859c335b8519cb</Hash>
</Codenesium>*/