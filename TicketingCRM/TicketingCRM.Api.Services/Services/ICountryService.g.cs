using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ICountryService
        {
                Task<CreateResponse<ApiCountryResponseModel>> Create(
                        ApiCountryRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiCountryRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiCountryResponseModel> Get(int id);

                Task<List<ApiCountryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>ecfa0536f0c09d1a67a3fd4d28999d6a</Hash>
</Codenesium>*/