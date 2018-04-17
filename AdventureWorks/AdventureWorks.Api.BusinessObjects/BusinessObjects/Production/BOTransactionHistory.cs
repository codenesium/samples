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
	public class BOTransactionHistory: AbstractBOTransactionHistory, IBOTransactionHistory
	{
		public BOTransactionHistory(
			ILogger<TransactionHistoryRepository> logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			ITransactionHistoryModelValidator transactionHistoryModelValidator)
			: base(logger, transactionHistoryRepository, transactionHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>964106a789d09a0a3e60348e375a4c51</Hash>
</Codenesium>*/