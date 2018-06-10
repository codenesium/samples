using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ICityService
        {
                Task<CreateResponse<ApiCityResponseModel>> Create(
                        ApiCityRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiCityRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiCityResponseModel> Get(int id);

                Task<List<ApiCityResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiCityResponseModel>> GetProvinceId(int provinceId);
        }
}

/*<Codenesium>
    <Hash>d2787374615189cd5c5ce14c04ddf152</Hash>
</Codenesium>*/