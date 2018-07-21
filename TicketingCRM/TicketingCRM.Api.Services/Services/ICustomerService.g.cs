using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ICustomerService
        {
                Task<CreateResponse<ApiCustomerResponseModel>> Create(
                        ApiCustomerRequestModel model);

                Task<UpdateResponse<ApiCustomerResponseModel>> Update(int id,
                                                                       ApiCustomerRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiCustomerResponseModel> Get(int id);

                Task<List<ApiCustomerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cd9d4e99a10be8bdf0ec1e08f720795d</Hash>
</Codenesium>*/