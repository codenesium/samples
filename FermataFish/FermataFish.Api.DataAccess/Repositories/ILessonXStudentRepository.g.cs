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

                Task<List<LessonXStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>5c31ab40baea8f2ee46230cda7bfa139</Hash>
</Codenesium>*/