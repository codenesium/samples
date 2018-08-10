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
    <Hash>af348864c6783e54bd41bf64f3c7a7f6</Hash>
</Codenesium>*/