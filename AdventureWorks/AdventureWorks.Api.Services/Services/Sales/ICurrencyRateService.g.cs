using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ICurrencyRateService
        {
                Task<CreateResponse<ApiCurrencyRateResponseModel>> Create(
                        ApiCurrencyRateRequestModel model);

                Task<ActionResponse> Update(int currencyRateID,
                                            ApiCurrencyRateRequestModel model);

                Task<ActionResponse> Delete(int currencyRateID);

                Task<ApiCurrencyRateResponseModel> Get(int currencyRateID);

                Task<List<ApiCurrencyRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiCurrencyRateResponseModel> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);
        }
}

/*<Codenesium>
    <Hash>0ef4e5c1d3e5608c88c19d094f4f9bb7</Hash>
</Codenesium>*/