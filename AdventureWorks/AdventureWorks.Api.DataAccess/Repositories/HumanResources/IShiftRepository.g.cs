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

		POCOShift Get(int shiftID);

		List<POCOShift> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>593d78eaf215debce594a4a9d829eff4</Hash>
</Codenesium>*/