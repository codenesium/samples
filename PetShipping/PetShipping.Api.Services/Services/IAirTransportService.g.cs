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

                Task<List<ApiAirTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>6969e9115b8035ed832a4752457fc40c</Hash>
</Codenesium>*/