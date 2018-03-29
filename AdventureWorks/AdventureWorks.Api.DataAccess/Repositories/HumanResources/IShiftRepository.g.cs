using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShiftRepository
	{
		int Create(string name,
		           TimeSpan startTime,
		           TimeSpan endTime,
		           DateTime modifiedDate);

		void Update(int shiftID, string name,
		            TimeSpan startTime,
		            TimeSpan endTime,
		            DateTime modifiedDate);

		void Delete(int shiftID);

		void GetById(int shiftID, Response response);

		void GetWhere(Expression<Func<EFShift, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ff19aff45a9a7dfa7b68525785928c10</Hash>
</Codenesium>*/