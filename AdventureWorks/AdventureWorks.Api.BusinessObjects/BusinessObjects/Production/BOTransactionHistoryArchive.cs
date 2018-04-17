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
			ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator)
			: base(logger, transactionHistoryArchiveRepository, transactionHistoryArchiveModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>93c5bfd9214a9a2b2730225a8db1f0b9</Hash>
</Codenesium>*/