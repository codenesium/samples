using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IAirlineService
        {
                Task<CreateResponse<ApiAirlineResponseModel>> Create(
                        ApiAirlineRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiAirlineRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiAirlineResponseModel> Get(int id);

                Task<List<ApiAirlineResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>425944bebd3346747627f6d09277ef86</Hash>
</Codenesium>*/