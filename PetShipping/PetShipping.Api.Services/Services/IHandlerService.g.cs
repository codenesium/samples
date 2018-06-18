using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IHandlerService
        {
                Task<CreateResponse<ApiHandlerResponseModel>> Create(
                        ApiHandlerRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiHandlerRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiHandlerResponseModel> Get(int id);

                Task<List<ApiHandlerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiAirTransportResponseModel>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int handlerId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiOtherTransportResponseModel>> OtherTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>751262abeb93a897c8c11f32e5a63d9a</Hash>
</Codenesium>*/