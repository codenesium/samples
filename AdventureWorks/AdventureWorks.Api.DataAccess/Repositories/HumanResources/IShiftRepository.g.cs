using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShiftRepository
	{
		POCOShift Create(ApiShiftModel model);

		void Update(int shiftID,
		            ApiShiftModel model);

		void Delete(int shiftID);

		POCOShift Get(int shiftID);

		List<POCOShift> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOShift GetName(string name);

		POCOShift GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>eaf30518cc63fee46e6f32113eba6218</Hash>
</Codenesium>*/