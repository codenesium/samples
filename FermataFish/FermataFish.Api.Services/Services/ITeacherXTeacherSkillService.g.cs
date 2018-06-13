using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ITeacherXTeacherSkillService
        {
                Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
                        ApiTeacherXTeacherSkillRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTeacherXTeacherSkillRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTeacherXTeacherSkillResponseModel> Get(int id);

                Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>55a454ddd9a88c2dd1bddf205b988b9d</Hash>
</Codenesium>*/