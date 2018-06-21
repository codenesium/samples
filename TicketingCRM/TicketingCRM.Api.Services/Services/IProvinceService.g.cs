using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IProvinceService
        {
                Task<CreateResponse<ApiProvinceResponseModel>> Create(
                        ApiProvinceRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiProvinceRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiProvinceResponseModel> Get(int id);

                Task<List<ApiProvinceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProvinceResponseModel>> GetCountryId(int countryId);

                Task<List<ApiCityResponseModel>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiVenueResponseModel>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cf075e57176e07ff35f9fb03a554a041</Hash>
</Codenesium>*/