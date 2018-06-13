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

                Task<List<EmployeePayHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>54c44ddcaa5598aa9b667ad3dc7f1659</Hash>
</Codenesium>*/