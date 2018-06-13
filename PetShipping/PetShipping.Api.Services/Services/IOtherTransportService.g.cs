using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IOtherTransportService
        {
                Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
                        ApiOtherTransportRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiOtherTransportRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiOtherTransportResponseModel> Get(int id);

                Task<List<ApiOtherTransportResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>37460851acb9bc5930aadd7ce48ed31f</Hash>
</Codenesium>*/