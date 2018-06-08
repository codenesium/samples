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

                Task<List<ApiStudentXFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4e1372f5f688699eeb5cd386f8f51b92</Hash>
</Codenesium>*/