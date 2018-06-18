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

                Task<List<ApiPipelineStepDestinationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f20d14517d4fa13db074a7c1516e7d3e</Hash>
</Codenesium>*/