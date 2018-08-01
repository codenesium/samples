using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class TransactionStatusRepository : AbstractTransactionStatusRepository, ITransactionStatusRepository
	{
		public TransactionStatusRepository(
			ILogger<TransactionStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9505d74a3d30b3df7d21af515ad27cdd</Hash>
</Codenesium>*/