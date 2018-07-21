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

                Task<UpdateResponse<ApiDestinationResponseModel>> Update(int id,
                                                                          ApiDestinationRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiDestinationResponseModel> Get(int id);

                Task<List<ApiDestinationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int destinationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6bde2b7103e208044ee65594747b002a</Hash>
</Codenesium>*/