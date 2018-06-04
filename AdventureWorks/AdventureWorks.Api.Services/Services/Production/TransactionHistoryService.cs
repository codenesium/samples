using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class TransactionHistoryService: AbstractTransactionHistoryService, ITransactionHistoryService
	{
		public TransactionHistoryService(
			ILogger<TransactionHistoryRepository> logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper BOLtransactionHistoryMapper,
			IDALTransactionHistoryMapper DALtransactionHistoryMapper)
			: base(logger, transactionHistoryRepository,
			       transactionHistoryModelValidator,
			       BOLtransactionHistoryMapper,
			       DALtransactionHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b4fbb1cad0a26ea350e9837634ff7ad6</Hash>
</Codenesium>*/