using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>cdbba73b73d5b6089088d19a035fa78e</Hash>
</Codenesium>*/