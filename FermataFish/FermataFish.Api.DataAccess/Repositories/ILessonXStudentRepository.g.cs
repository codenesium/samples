using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ILessonXStudentRepository
        {
                Task<LessonXStudent> Create(LessonXStudent item);

                Task Update(LessonXStudent item);

                Task Delete(int id);

                Task<LessonXStudent> Get(int id);

                Task<List<LessonXStudent>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4d2e4b5f1ba13dcf3e026ed623fdf0ca</Hash>
</Codenesium>*/