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

                Task<List<ApiCountryRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6b6e42b86a83d7631fdfc21b5fe429aa</Hash>
</Codenesium>*/