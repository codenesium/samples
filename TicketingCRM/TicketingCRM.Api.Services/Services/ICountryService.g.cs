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

                Task<List<ApiCountryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProvinceResponseModel>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2b380ed228ff9ad27518d11d7436392f</Hash>
</Codenesium>*/