using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		int Create(
			DateTime errorTime,
			string userName,
			int errorNumber,
			Nullable<int> errorSeverity,
			Nullable<int> errorState,
			string errorProcedure,
			Nullable<int> errorLine,
			string errorMessage);

		void Update(int errorLogID,
		            DateTime errorTime,
		            string userName,
		            int errorNumber,
		            Nullable<int> errorSeverity,
		            Nullable<int> errorState,
		            string errorProcedure,
		            Nullable<int> errorLine,
		            string errorMessage);

		void Delete(int errorLogID);

		Response GetById(int errorLogID);

		POCOErrorLog GetByIdDirect(int errorLogID);

		Response GetWhere(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOErrorLog> GetWhereDirect(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f1ce6efed894d77d48b987bd4fff2f79</Hash>
</Codenesium>*/