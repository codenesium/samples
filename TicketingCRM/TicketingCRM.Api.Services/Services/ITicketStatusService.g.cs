using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ITicketStatusService
        {
                Task<CreateResponse<ApiTicketStatusResponseModel>> Create(
                        ApiTicketStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTicketStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTicketStatusResponseModel> Get(int id);

                Task<List<ApiTicketStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>98236a90ea41c30e6bd458893c996c5f</Hash>
</Codenesium>*/