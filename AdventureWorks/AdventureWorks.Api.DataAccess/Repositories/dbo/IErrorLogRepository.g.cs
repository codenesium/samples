using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		int Create(DateTime errorTime,
		           string userName,
		           int errorNumber,
		           Nullable<int> errorSeverity,
		           Nullable<int> errorState,
		           string errorProcedure,
		           Nullable<int> errorLine,
		           string errorMessage);

		void Update(int errorLogID, DateTime errorTime,
		            string userName,
		            int errorNumber,
		            Nullable<int> errorSeverity,
		            Nullable<int> errorState,
		            string errorProcedure,
		            Nullable<int> errorLine,
		            string errorMessage);

		void Delete(int errorLogID);

		void GetById(int errorLogID, Response response);

		void GetWhere(Expression<Func<EFErrorLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9868c985c5688cb391f6056187807780</Hash>
</Codenesium>*/