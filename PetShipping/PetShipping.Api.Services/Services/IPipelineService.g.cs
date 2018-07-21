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

                Task<UpdateResponse<ApiPipelineResponseModel>> Update(int id,
                                                                       ApiPipelineRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineResponseModel> Get(int id);

                Task<List<ApiPipelineResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>40d6c75fb11f1a5f58952438a872e664</Hash>
</Codenesium>*/