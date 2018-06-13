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

                Task<List<LessonXTeacher>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>88fee7de880f282a7880ebda90cedac3</Hash>
</Codenesium>*/