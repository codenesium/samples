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

                Task<List<ApiCurrencyRateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCurrencyRateResponseModel> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d33ef27fe10a155a9ea3eafba5439656</Hash>
</Codenesium>*/