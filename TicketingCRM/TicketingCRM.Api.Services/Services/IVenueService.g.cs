using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

                Task<List<ApiVenueResponseModel>> ByAdminId(int adminId);

                Task<List<ApiVenueResponseModel>> ByProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>51e596f1cecdb1bf78fb4b65b9606411</Hash>
</Codenesium>*/