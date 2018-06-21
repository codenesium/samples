using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IEmployeePayHistoryRepository
        {
                Task<EmployeePayHistory> Create(EmployeePayHistory item);

                Task Update(EmployeePayHistory item);

                Task Delete(int businessEntityID);

                Task<EmployeePayHistory> Get(int businessEntityID);

                Task<List<EmployeePayHistory>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5428ea670feca962d8466d9fd9a6f9aa</Hash>
</Codenesium>*/