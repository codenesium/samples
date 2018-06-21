using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ILessonXStudentService
        {
                Task<CreateResponse<ApiLessonXStudentResponseModel>> Create(
                        ApiLessonXStudentRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLessonXStudentRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonXStudentResponseModel> Get(int id);

                Task<List<ApiLessonXStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8a2d33d1f3e8e640560117ae872596a1</Hash>
</Codenesium>*/