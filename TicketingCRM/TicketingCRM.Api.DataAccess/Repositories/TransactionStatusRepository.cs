using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>a3cbda694750588259961600d90d7ed8</Hash>
</Codenesium>*/