using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ICustomerService
        {
                Task<CreateResponse<ApiCustomerResponseModel>> Create(
                        ApiCustomerRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiCustomerRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiCustomerResponseModel> Get(int id);

                Task<List<ApiCustomerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9967af656e201b4467d6327bc81dbd10</Hash>
</Codenesium>*/