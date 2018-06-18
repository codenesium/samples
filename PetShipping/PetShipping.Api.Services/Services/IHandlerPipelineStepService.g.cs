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

                Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>27bf85775a0cb4dfb440a711a6e5a21f</Hash>
</Codenesium>*/