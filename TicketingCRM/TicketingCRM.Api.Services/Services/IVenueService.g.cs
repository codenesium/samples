using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IVenueService
        {
                Task<CreateResponse<ApiVenueResponseModel>> Create(
                        ApiVenueRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiVenueRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiVenueResponseModel> Get(int id);

                Task<List<ApiVenueResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiVenueResponseModel>> GetAdminId(int adminId);
                Task<List<ApiVenueResponseModel>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>2ea000cb109561f9825f73f36e9ea338</Hash>
</Codenesium>*/