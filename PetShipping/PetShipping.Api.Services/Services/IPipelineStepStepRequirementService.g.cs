using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>40fa0de0dbc88188d56808e7bc990a20</Hash>
</Codenesium>*/