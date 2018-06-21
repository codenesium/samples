using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiCountryRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8ff708b65e4560a791c85bfb6fb12b5c</Hash>
</Codenesium>*/