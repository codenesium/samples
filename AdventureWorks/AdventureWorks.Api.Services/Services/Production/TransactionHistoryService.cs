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
    <Hash>e6ced5ae05d17ab354aa771bed64e341</Hash>
</Codenesium>*/