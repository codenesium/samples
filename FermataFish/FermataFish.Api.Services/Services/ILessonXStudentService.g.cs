using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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

                Task<List<ApiLessonXStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>fef9969416b99b441b4d6633b057bba1</Hash>
</Codenesium>*/