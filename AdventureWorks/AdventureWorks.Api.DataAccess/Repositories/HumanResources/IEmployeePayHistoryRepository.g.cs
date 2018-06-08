using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IEmployeePayHistoryRepository
        {
                Task<EmployeePayHistory> Create(EmployeePayHistory item);

                Task Update(EmployeePayHistory item);

                Task Delete(int businessEntityID);

                Task<EmployeePayHistory> Get(int businessEntityID);

                Task<List<EmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2ac11d052b5ba887eaa822edf431b1d5</Hash>
</Codenesium>*/