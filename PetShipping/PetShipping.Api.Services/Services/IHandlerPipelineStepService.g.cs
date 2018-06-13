using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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

                Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>06d8bd5dfbd9dad9050f372994ce29d6</Hash>
</Codenesium>*/