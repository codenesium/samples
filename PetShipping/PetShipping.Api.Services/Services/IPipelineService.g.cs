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

                Task<List<ApiPipelineResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>25546eec70ec54176fc2299538d64f1f</Hash>
</Codenesium>*/