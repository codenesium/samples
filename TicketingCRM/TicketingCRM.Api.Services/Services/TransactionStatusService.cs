using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TransactionStatusService : AbstractTransactionStatusService, ITransactionStatusService
	{
		public TransactionStatusService(
			ILogger<ITransactionStatusRepository> logger,
			ITransactionStatusRepository transactionStatusRepository,
			IApiTransactionStatusRequestModelValidator transactionStatusModelValidator,
			IBOLTransactionStatusMapper boltransactionStatusMapper,
			IDALTransactionStatusMapper daltransactionStatusMapper,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper
			)
			: base(logger,
			       transactionStatusRepository,
			       transactionStatusModelValidator,
			       boltransactionStatusMapper,
			       daltransactionStatusMapper,
			       bolTransactionMapper,
			       dalTransactionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>27c772db7f56c797bcd84bb7e1fa1132</Hash>
</Codenesium>*/