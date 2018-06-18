using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ILessonStatusService
        {
                Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
                        ApiLessonStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLessonStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonStatusResponseModel> Get(int id);

                Task<List<ApiLessonStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLessonResponseModel>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>89e2aee36915252a536412e94d3d85cf</Hash>
</Codenesium>*/