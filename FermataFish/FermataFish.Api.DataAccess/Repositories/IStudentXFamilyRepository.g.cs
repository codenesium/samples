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

                Task<List<StudentXFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>1a362c1a58c6f1dbe9e0aa14838fd59f</Hash>
</Codenesium>*/