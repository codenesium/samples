using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineService
        {
                Task<CreateResponse<ApiPipelineResponseModel>> Create(
                        ApiPipelineRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineResponseModel> Get(int id);

                Task<List<ApiPipelineResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8ff5f7ad10b2faa00f2be3ab5e1c07d2</Hash>
</Codenesium>*/