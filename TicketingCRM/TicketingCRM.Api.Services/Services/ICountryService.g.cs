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

                Task<List<ApiCountryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiProvinceResponseModel>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>04759b1f23cd42526f82fca1ad0da36a</Hash>
</Codenesium>*/