using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ITeacherSkillService
        {
                Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
                        ApiTeacherSkillRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTeacherSkillRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTeacherSkillResponseModel> Get(int id);

                Task<List<ApiTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiRateResponseModel>> Rates(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>933b5ba97842659431775f5a6f79f6b4</Hash>
</Codenesium>*/