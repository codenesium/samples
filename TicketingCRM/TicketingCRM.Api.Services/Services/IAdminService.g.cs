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

                Task<List<ApiAdminResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>681c19129f1ae6c6382839cb52efd677</Hash>
</Codenesium>*/