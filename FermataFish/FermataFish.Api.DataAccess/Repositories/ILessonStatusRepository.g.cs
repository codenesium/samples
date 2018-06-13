using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ILessonStatusRepository
        {
                Task<LessonStatus> Create(LessonStatus item);

                Task Update(LessonStatus item);

                Task Delete(int id);

                Task<LessonStatus> Get(int id);

                Task<List<LessonStatus>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Lesson>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>3cdd7d8ee6dafd1b6ba30486843aba69</Hash>
</Codenesium>*/