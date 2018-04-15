using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
	{
		int Create(TransactionHistoryArchiveModel model);

		void Update(int transactionID,
		            TransactionHistoryArchiveModel model);

		void Delete(int transactionID);

		ApiResponse GetById(int transactionID);

		POCOTransactionHistoryArchive GetByIdDirect(int transactionID);

		ApiResponse GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistoryArchive> GetWhereDirect(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2498dc15b2941f4b6bd7f8b5ffa80809</Hash>
</Codenesium>*/