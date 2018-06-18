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

                Task<List<LessonStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Lesson>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0);

                Task<Studio> GetStudio(int id);
        }
}

/*<Codenesium>
    <Hash>f990c25029251ca46b1364540c58eb78</Hash>
</Codenesium>*/