using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiRateResponseModel>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5a06251e3e42c9987a4fd2d392852fc6</Hash>
</Codenesium>*/