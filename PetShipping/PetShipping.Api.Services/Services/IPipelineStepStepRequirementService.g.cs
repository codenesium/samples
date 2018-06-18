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

                Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0690ffc4b908fb177227b5510ad1dd1f</Hash>
</Codenesium>*/