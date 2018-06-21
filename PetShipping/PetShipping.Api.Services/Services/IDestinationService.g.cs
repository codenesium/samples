using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IDestinationService
        {
                Task<CreateResponse<ApiDestinationResponseModel>> Create(
                        ApiDestinationRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiDestinationRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiDestinationResponseModel> Get(int id);

                Task<List<ApiDestinationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int destinationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a0c65204591becd2d7a63ae875a58894</Hash>
</Codenesium>*/