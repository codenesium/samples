using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShiftRepository
	{
		int Create(
			string name,
			TimeSpan startTime,
			TimeSpan endTime,
			DateTime modifiedDate);

		void Update(int shiftID,
		            string name,
		            TimeSpan startTime,
		            TimeSpan endTime,
		            DateTime modifiedDate);

		void Delete(int shiftID);

		Response GetById(int shiftID);

		POCOShift GetByIdDirect(int shiftID);

		Response GetWhere(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShift> GetWhereDirect(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f7f23452eed877da8ec4fa87de368fcf</Hash>
</Codenesium>*/