using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IShiftRepository
        {
                Task<Shift> Create(Shift item);

                Task Update(Shift item);

                Task Delete(int shiftID);

                Task<Shift> Get(int shiftID);

                Task<List<Shift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Shift> GetName(string name);
                Task<Shift> GetStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);
        }
}

/*<Codenesium>
    <Hash>38a41634d415e2aac3bafde64b50909d</Hash>
</Codenesium>*/