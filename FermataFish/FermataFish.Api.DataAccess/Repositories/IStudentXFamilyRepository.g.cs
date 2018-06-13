using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IStudentXFamilyRepository
        {
                Task<StudentXFamily> Create(StudentXFamily item);

                Task Update(StudentXFamily item);

                Task Delete(int id);

                Task<StudentXFamily> Get(int id);

                Task<List<StudentXFamily>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e24f988dae684fb5771cf500c064ec86</Hash>
</Codenesium>*/