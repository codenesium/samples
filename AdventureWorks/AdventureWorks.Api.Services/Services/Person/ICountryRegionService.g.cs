using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ICountryRegionService
        {
                Task<CreateResponse<ApiCountryRegionResponseModel>> Create(
                        ApiCountryRegionRequestModel model);

                Task<ActionResponse> Update(string countryRegionCode,
                                            ApiCountryRegionRequestModel model);

                Task<ActionResponse> Delete(string countryRegionCode);

                Task<ApiCountryRegionResponseModel> Get(string countryRegionCode);

                Task<List<ApiCountryRegionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiCountryRegionResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>af170fc141496818b8191ce7eda711a6</Hash>
</Codenesium>*/