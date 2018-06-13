using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ILessonXTeacherService
        {
                Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
                        ApiLessonXTeacherRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLessonXTeacherRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonXTeacherResponseModel> Get(int id);

                Task<List<ApiLessonXTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8120606dcdceb1828b43e78015d78b13</Hash>
</Codenesium>*/