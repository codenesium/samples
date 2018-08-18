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
	public partial class TransactionService : AbstractTransactionService, ITransactionService
	{
		public TransactionService(
			ILogger<ITransactionRepository> logger,
			ITransactionRepository transactionRepository,
			IApiTransactionRequestModelValidator transactionModelValidator,
			IBOLTransactionMapper boltransactionMapper,
			IDALTransactionMapper daltransactionMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper
			)
			: base(logger,
			       transactionRepository,
			       transactionModelValidator,
			       boltransactionMapper,
			       daltransactionMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c4c1244f8bcc5fa276aa940bb4dcd247</Hash>
</Codenesium>*/