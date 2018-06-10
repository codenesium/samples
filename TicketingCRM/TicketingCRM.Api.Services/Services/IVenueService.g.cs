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

                Task<List<ApiVenueResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiVenueResponseModel>> GetAdminId(int adminId);
                Task<List<ApiVenueResponseModel>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>0318b0166d57476b26a9e001dcccb593</Hash>
</Codenesium>*/