using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepDestinationService
        {
                Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> Create(
                        ApiPipelineStepDestinationRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStepDestinationRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepDestinationResponseModel> Get(int id);

                Task<List<ApiPipelineStepDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>b267248ba0819612a81a479b9111f09e</Hash>
</Codenesium>*/