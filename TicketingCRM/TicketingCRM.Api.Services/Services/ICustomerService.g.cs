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

                Task<List<ApiCustomerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>b5b884cc529b3f01ee56d5557c0ae4cb</Hash>
</Codenesium>*/