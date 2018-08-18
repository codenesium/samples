using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALTransactionHistoryArchiveMapper
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
    <Hash>97e120b9247152db8c2ede52474fb46b</Hash>
</Codenesium>*/