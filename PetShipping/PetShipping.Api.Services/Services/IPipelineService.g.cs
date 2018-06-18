using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>59b6ea71a5cc275952bdbb4c1d21aa9c</Hash>
</Codenesium>*/