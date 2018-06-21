using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>3c9b9233d962c476b03e4231d2233765</Hash>
</Codenesium>*/