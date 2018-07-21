using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IHandlerPipelineStepService
        {
                Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
                        ApiHandlerPipelineStepRequestModel model);

                Task<UpdateResponse<ApiHandlerPipelineStepResponseModel>> Update(int id,
                                                                                  ApiHandlerPipelineStepRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiHandlerPipelineStepResponseModel> Get(int id);

                Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1605f8a24f1beba1665b22ac568d9771</Hash>
</Codenesium>*/