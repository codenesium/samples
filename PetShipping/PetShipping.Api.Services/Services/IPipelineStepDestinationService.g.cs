using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepDestinationService
        {
                Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> Create(
                        ApiPipelineStepDestinationRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStepDestinationRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepDestinationResponseModel> Get(int id);

                Task<List<ApiPipelineStepDestinationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>48bd4d8b6cdcb2374cb8e5c28e213650</Hash>
</Codenesium>*/