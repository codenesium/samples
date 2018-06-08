using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IStudentRepository
        {
                Task<Student> Create(Student item);

                Task Update(Student item);

                Task Delete(int id);

                Task<Student> Get(int id);

                Task<List<Student>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>337807102075342af7f7ba3164dbb2e7</Hash>
</Codenesium>*/