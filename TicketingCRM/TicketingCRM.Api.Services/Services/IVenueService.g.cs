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

                Task<List<ApiVenueResponseModel>> GetAdminId(int adminId);

                Task<List<ApiVenueResponseModel>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>28aae5529259db9bb64561508314ab9c</Hash>
</Codenesium>*/