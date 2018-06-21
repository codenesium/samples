using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>4dfc1070c20a1b43f5743b0962ca26b2</Hash>
</Codenesium>*/