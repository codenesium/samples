using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ILessonStatusService
        {
                Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
                        ApiLessonStatusRequestModel model);

                Task<UpdateResponse<ApiLessonStatusResponseModel>> Update(int id,
                                                                           ApiLessonStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonStatusResponseModel> Get(int id);

                Task<List<ApiLessonStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLessonResponseModel>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d1796f7910d09880c79d2f0cf22f85e7</Hash>
</Codenesium>*/