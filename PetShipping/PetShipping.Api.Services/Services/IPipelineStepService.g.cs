using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepService
        {
                Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
                        ApiPipelineStepRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStepRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepResponseModel> Get(int id);

                Task<List<ApiPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9217f6d4bf5b21a47151382610c25783</Hash>
</Codenesium>*/