using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ITeacherService
        {
                Task<CreateResponse<ApiTeacherResponseModel>> Create(
                        ApiTeacherRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTeacherRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTeacherResponseModel> Get(int id);

                Task<List<ApiTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiRateResponseModel>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>adccff87ba05c4d337f2bcbbc827f1ef</Hash>
</Codenesium>*/