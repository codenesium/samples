using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<List<ApiProvinceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiProvinceResponseModel>> GetCountryId(int countryId);
        }
}

/*<Codenesium>
    <Hash>e3204080b9f5138fc7fc7c79dfd36b5a</Hash>
</Codenesium>*/