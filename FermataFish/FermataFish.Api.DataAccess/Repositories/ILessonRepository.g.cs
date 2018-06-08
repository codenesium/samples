using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ILessonRepository
        {
                Task<Lesson> Create(Lesson item);

                Task Update(Lesson item);

                Task Delete(int id);

                Task<Lesson> Get(int id);

                Task<List<Lesson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4145f4666e2f0f5e6e109941d6126eee</Hash>
</Codenesium>*/