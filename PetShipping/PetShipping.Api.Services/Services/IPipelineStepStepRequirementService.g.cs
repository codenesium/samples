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

                Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>c9887e0fde6f852e42f9318a1475eb3f</Hash>
</Codenesium>*/