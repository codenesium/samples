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

                Task<List<ApiHandlerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiAirTransportResponseModel>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int handlerId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiOtherTransportResponseModel>> OtherTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ab172a8abe20488e81b920cbd98c778f</Hash>
</Codenesium>*/