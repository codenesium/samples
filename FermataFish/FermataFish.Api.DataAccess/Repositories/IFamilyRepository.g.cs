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

                Task<List<Family>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Student>> Students(int familyId, int limit = int.MaxValue, int offset = 0);
                Task<List<StudentXFamily>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0);

                Task<Studio> GetStudio(int id);
        }
}

/*<Codenesium>
    <Hash>0e5411be554897e3a6f4ad8ed2dd53a3</Hash>
</Codenesium>*/