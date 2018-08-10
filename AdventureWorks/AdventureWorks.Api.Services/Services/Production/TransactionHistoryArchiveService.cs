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
	public partial class TransactionHistoryArchiveService : AbstractTransactionHistoryArchiveService, ITransactionHistoryArchiveService
	{
		public TransactionHistoryArchiveService(
			ILogger<ITransactionHistoryArchiveRepository> logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper boltransactionHistoryArchiveMapper,
			IDALTransactionHistoryArchiveMapper daltransactionHistoryArchiveMapper
			)
			: base(logger,
			       transactionHistoryArchiveRepository,
			       transactionHistoryArchiveModelValidator,
			       boltransactionHistoryArchiveMapper,
			       daltransactionHistoryArchiveMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6819ce3b937eb7bbeee2c9c754aa7de1</Hash>
</Codenesium>*/