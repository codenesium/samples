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

                Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f2542b18f13a4daf6481609d3d7e2cf9</Hash>
</Codenesium>*/