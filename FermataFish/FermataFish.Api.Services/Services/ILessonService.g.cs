using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ILessonService
        {
                Task<CreateResponse<ApiLessonResponseModel>> Create(
                        ApiLessonRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLessonRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonResponseModel> Get(int id);

                Task<List<ApiLessonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a796c736cb08b31403e87b6484ba2c5d</Hash>
</Codenesium>*/