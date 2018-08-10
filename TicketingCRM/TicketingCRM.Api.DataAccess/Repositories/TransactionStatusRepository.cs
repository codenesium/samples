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
    <Hash>a556e0f95ffb8dd8c4e7e92da809a94f</Hash>
</Codenesium>*/