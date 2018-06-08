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

                Task<List<LessonStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f0b968a61db09b5b64ba975bb8ee8e57</Hash>
</Codenesium>*/