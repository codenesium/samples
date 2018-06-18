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

                Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>311e5a83406cf0a186a6bad7fbca92bb</Hash>
</Codenesium>*/