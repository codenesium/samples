using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class TransactionHistoryService : AbstractTransactionHistoryService, ITransactionHistoryService
	{
		public TransactionHistoryService(
			ILogger<ITransactionHistoryRepository> logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper boltransactionHistoryMapper,
			IDALTransactionHistoryMapper daltransactionHistoryMapper
			)
			: base(logger,
			       transactionHistoryRepository,
			       transactionHistoryModelValidator,
			       boltransactionHistoryMapper,
			       daltransactionHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>52783c9b763a5f1f291d1e180b9828a0</Hash>
</Codenesium>*/