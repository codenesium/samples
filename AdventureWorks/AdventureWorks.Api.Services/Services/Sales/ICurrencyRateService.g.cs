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

                Task<List<ApiCurrencyRateResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiCurrencyRateResponseModel> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8f90e78545110e44d52d2b8d7479d905</Hash>
</Codenesium>*/