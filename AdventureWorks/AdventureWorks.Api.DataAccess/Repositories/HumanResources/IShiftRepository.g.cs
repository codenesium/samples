using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShiftRepository
	{
		Task<DTOShift> Create(DTOShift dto);

		Task Update(int shiftID,
		            DTOShift dto);

		Task Delete(int shiftID);

		Task<DTOShift> Get(int shiftID);

		Task<List<DTOShift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOShift> GetName(string name);
		Task<DTOShift> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>c5a77dc8b2cd62a94102cad0fafc802d</Hash>
</Codenesium>*/