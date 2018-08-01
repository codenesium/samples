using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
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
    <Hash>e9d3099ad803156896400b7a00213f9e</Hash>
</Codenesium>*/