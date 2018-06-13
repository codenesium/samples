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

                Task<List<ApiStudentXFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>b859b4beabf0628af2bc793a0bf4b48c</Hash>
</Codenesium>*/