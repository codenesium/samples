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

                Task<List<ApiVenueResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiVenueResponseModel>> GetAdminId(int adminId);
                Task<List<ApiVenueResponseModel>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>a79ee93d494135cd509bc27b78f16f18</Hash>
</Codenesium>*/