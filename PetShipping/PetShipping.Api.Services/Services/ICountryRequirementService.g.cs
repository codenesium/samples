using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface ICountryRequirementService
        {
                Task<CreateResponse<ApiCountryRequirementResponseModel>> Create(
                        ApiCountryRequirementRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiCountryRequirementRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiCountryRequirementResponseModel> Get(int id);

                Task<List<ApiCountryRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>ef6bbe49e483019ae2dad6aba6618f31</Hash>
</Codenesium>*/