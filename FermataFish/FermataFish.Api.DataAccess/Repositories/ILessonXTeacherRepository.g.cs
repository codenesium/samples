using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ILessonXTeacherRepository
        {
                Task<LessonXTeacher> Create(LessonXTeacher item);

                Task Update(LessonXTeacher item);

                Task Delete(int id);

                Task<LessonXTeacher> Get(int id);

                Task<List<LessonXTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3b4db25e4446ce66e773a15e56b4b97b</Hash>
</Codenesium>*/