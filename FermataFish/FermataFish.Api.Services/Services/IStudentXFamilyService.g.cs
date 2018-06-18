using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IStudentXFamilyService
        {
                Task<CreateResponse<ApiStudentXFamilyResponseModel>> Create(
                        ApiStudentXFamilyRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiStudentXFamilyRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiStudentXFamilyResponseModel> Get(int id);

                Task<List<ApiStudentXFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e84971d2db5f11391a3a5638cbc6bd3b</Hash>
</Codenesium>*/