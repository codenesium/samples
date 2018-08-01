using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>06d7a20028bb950298ba9a2cd9d7f257</Hash>
</Codenesium>*/