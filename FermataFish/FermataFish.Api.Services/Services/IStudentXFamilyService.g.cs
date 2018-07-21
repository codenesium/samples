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

                Task<UpdateResponse<ApiStudentXFamilyResponseModel>> Update(int id,
                                                                             ApiStudentXFamilyRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiStudentXFamilyResponseModel> Get(int id);

                Task<List<ApiStudentXFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7f50e117f348e76d664d5c84dc1f9114</Hash>
</Codenesium>*/