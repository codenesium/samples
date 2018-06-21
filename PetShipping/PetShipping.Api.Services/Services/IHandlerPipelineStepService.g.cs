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

                Task<ActionResponse> Update(int id,
                                            ApiHandlerPipelineStepRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiHandlerPipelineStepResponseModel> Get(int id);

                Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6cc64f60ece7acc4c68f3c2fbbbd517a</Hash>
</Codenesium>*/