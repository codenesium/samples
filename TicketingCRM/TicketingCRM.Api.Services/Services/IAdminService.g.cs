using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IAdminService
        {
                Task<CreateResponse<ApiAdminResponseModel>> Create(
                        ApiAdminRequestModel model);

                Task<UpdateResponse<ApiAdminResponseModel>> Update(int id,
                                                                    ApiAdminRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiAdminResponseModel> Get(int id);

                Task<List<ApiAdminResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiVenueResponseModel>> Venues(int adminId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>22ae33bc96245f26d4cf961f1cea461c</Hash>
</Codenesium>*/