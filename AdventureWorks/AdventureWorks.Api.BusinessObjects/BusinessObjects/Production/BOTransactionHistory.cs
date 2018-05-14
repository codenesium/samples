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
			IApiTransactionHistoryModelValidator transactionHistoryModelValidator)
			: base(logger, transactionHistoryRepository, transactionHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6682629d221adc9cc3a315127a1ad626</Hash>
</Codenesium>*/