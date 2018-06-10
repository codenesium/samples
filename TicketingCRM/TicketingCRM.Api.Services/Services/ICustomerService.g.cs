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

                Task<List<ApiCustomerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>fe52b1dfd2dfc70b908d564fb90a0262</Hash>
</Codenesium>*/