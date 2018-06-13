using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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

                Task<List<ApiFamilyResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiStudentResponseModel>> Students(int familyId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9703212a0257aebdd29cf8739387edc3</Hash>
</Codenesium>*/