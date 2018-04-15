using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShiftRepository
	{
		int Create(ShiftModel model);

		void Update(int shiftID,
		            ShiftModel model);

		void Delete(int shiftID);

		ApiResponse GetById(int shiftID);

		POCOShift GetByIdDirect(int shiftID);

		ApiResponse GetWhere(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShift> GetWhereDirect(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>11ad9a9561f3131259e6d54fe2cb5ca6</Hash>
</Codenesium>*/