using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ITeacherRepository
        {
                Task<Teacher> Create(Teacher item);

                Task Update(Teacher item);

                Task Delete(int id);

                Task<Teacher> Get(int id);

                Task<List<Teacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a5f7f0ffe04c77c20c6000d32ef8adee</Hash>
</Codenesium>*/