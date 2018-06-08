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

                Task<List<ApiHandlerPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>50bd5e66e1416f6fd1f3676f39fb1f50</Hash>
</Codenesium>*/