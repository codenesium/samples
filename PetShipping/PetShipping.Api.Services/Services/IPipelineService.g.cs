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

                Task<List<ApiPipelineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>0ab7f5b4e879f01cc1c60433ddb6699c</Hash>
</Codenesium>*/