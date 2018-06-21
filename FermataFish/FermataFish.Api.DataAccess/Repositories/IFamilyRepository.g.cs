using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>1b7e04a87a5594bc1f22e442800f201e</Hash>
</Codenesium>*/