using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class TransactionHistoryArchiveRepository : AbstractTransactionHistoryArchiveRepository, ITransactionHistoryArchiveRepository
	{
		public TransactionHistoryArchiveRepository(
			ILogger<TransactionHistoryArchiveRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6d554eea5929bc59ea05b09081d0b114</Hash>
</Codenesium>*/