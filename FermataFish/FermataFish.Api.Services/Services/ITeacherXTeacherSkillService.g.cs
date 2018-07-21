using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ITeacherXTeacherSkillService
        {
                Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
                        ApiTeacherXTeacherSkillRequestModel model);

                Task<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>> Update(int id,
                                                                                   ApiTeacherXTeacherSkillRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTeacherXTeacherSkillResponseModel> Get(int id);

                Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>852d36ad2378be192dd26ba027743ba8</Hash>
</Codenesium>*/