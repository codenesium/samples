using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IAirTransportService
        {
                Task<CreateResponse<ApiAirTransportResponseModel>> Create(
                        ApiAirTransportRequestModel model);

                Task<ActionResponse> Update(int airlineId,
                                            ApiAirTransportRequestModel model);

                Task<ActionResponse> Delete(int airlineId);

                Task<ApiAirTransportResponseModel> Get(int airlineId);

                Task<List<ApiAirTransportResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>68315577962142fa4ed96881d5281078</Hash>
</Codenesium>*/