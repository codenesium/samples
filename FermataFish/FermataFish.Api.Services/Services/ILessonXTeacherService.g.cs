using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiLessonXTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>18eecb6efe3b27a33cf7f403a49b2c56</Hash>
</Codenesium>*/