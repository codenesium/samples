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

                Task<List<ApiDestinationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int destinationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a42b6ab1c64c6c77c863c5dd35014fc1</Hash>
</Codenesium>*/