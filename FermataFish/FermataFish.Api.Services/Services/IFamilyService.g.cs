using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IFamilyService
        {
                Task<CreateResponse<ApiFamilyResponseModel>> Create(
                        ApiFamilyRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiFamilyRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiFamilyResponseModel> Get(int id);

                Task<List<ApiFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiStudentResponseModel>> Students(int familyId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>64b70cee7b63b3aa6318cefd7bc9ed13</Hash>
</Codenesium>*/