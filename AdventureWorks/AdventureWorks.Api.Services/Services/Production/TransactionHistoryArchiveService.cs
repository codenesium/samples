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
	public class TransactionHistoryArchiveService: AbstractTransactionHistoryArchiveService, ITransactionHistoryArchiveService
	{
		public TransactionHistoryArchiveService(
			ILogger<TransactionHistoryArchiveRepository> logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper BOLtransactionHistoryArchiveMapper,
			IDALTransactionHistoryArchiveMapper DALtransactionHistoryArchiveMapper)
			: base(logger, transactionHistoryArchiveRepository,
			       transactionHistoryArchiveModelValidator,
			       BOLtransactionHistoryArchiveMapper,
			       DALtransactionHistoryArchiveMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e2c41da92b2e4aa4e3d9473091b7bf52</Hash>
</Codenesium>*/