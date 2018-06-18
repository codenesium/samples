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

                Task<List<EmployeePayHistory>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>815512a071ee0194d7907686d31d4a17</Hash>
</Codenesium>*/