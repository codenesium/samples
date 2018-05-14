using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOTransactionHistoryArchive: AbstractBOTransactionHistoryArchive, IBOTransactionHistoryArchive
	{
		public BOTransactionHistoryArchive(
			ILogger<TransactionHistoryArchiveRepository> logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator)
			: base(logger, transactionHistoryArchiveRepository, transactionHistoryArchiveModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>dfd917b3e15402275ae186f52fd7dba6</Hash>
</Codenesium>*/