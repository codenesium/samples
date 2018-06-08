using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IDepartmentRepository
        {
                Task<Department> Create(Department item);

                Task Update(Department item);

                Task Delete(short departmentID);

                Task<Department> Get(short departmentID);

                Task<List<Department>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Department> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>0b1e8996a22f2c81f5aa3473a073d19c</Hash>
</Codenesium>*/