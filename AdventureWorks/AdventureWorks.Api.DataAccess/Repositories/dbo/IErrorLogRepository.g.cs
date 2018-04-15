using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		int Create(ErrorLogModel model);

		void Update(int errorLogID,
		            ErrorLogModel model);

		void Delete(int errorLogID);

		ApiResponse GetById(int errorLogID);

		POCOErrorLog GetByIdDirect(int errorLogID);

		ApiResponse GetWhere(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOErrorLog> GetWhereDirect(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>359b45c6e6a38115948270092570baed</Hash>
</Codenesium>*/