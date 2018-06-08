using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IHandlerService
        {
                Task<CreateResponse<ApiHandlerResponseModel>> Create(
                        ApiHandlerRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiHandlerRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiHandlerResponseModel> Get(int id);

                Task<List<ApiHandlerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f79775bbf907dc14b29ece5833aac226</Hash>
</Codenesium>*/