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
			IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper transactionHistoryMapper)
			: base(logger, transactionHistoryRepository, transactionHistoryModelValidator, transactionHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>129299d606cd18274468a26bebc1077d</Hash>
</Codenesium>*/