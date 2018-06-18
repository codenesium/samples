using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IAdminService
        {
                Task<CreateResponse<ApiAdminResponseModel>> Create(
                        ApiAdminRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiAdminRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiAdminResponseModel> Get(int id);

                Task<List<ApiAdminResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiVenueResponseModel>> Venues(int adminId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1dd2e60b43fbc3d39174cb48e97709b1</Hash>
</Codenesium>*/