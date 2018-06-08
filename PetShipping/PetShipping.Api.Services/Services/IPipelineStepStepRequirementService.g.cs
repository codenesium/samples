using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepStepRequirementService
        {
                Task<CreateResponse<ApiPipelineStepStepRequirementResponseModel>> Create(
                        ApiPipelineStepStepRequirementRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStepStepRequirementRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepStepRequirementResponseModel> Get(int id);

                Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a1312d1f460da69a35b5e89e3066e03a</Hash>
</Codenesium>*/