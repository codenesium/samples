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
			IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper transactionHistoryArchiveMapper)
			: base(logger, transactionHistoryArchiveRepository, transactionHistoryArchiveModelValidator, transactionHistoryArchiveMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1f93fadf98fde96af6a0287175b5250a</Hash>
</Codenesium>*/