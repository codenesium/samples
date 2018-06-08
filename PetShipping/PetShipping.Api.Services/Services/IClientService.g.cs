using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IClientService
        {
                Task<CreateResponse<ApiClientResponseModel>> Create(
                        ApiClientRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiClientRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiClientResponseModel> Get(int id);

                Task<List<ApiClientResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3effaca59540370466db454cd44affd6</Hash>
</Codenesium>*/