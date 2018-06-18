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

                Task<List<ApiLessonXTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>11081bc654baa950c7b23d803ac59989</Hash>
</Codenesium>*/