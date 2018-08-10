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
    <Hash>4ad9d0b151b08d60e7806d2f1e0a1dce</Hash>
</Codenesium>*/