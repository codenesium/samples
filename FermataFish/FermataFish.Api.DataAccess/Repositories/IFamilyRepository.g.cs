using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IFamilyRepository
        {
                Task<Family> Create(Family item);

                Task Update(Family item);

                Task Delete(int id);

                Task<Family> Get(int id);

                Task<List<Family>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Student>> Students(int familyId, int limit = int.MaxValue, int offset = 0);
                Task<List<StudentXFamily>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4d0a27e57d15873feb7c47ca9eb8574f</Hash>
</Codenesium>*/