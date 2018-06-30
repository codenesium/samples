using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>543f0e5d56257da91cd32b366156cc02</Hash>
</Codenesium>*/