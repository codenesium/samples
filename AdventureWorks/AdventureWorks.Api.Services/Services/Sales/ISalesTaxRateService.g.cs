using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesTaxRateService
        {
                Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
                        ApiSalesTaxRateRequestModel model);

                Task<ActionResponse> Update(int salesTaxRateID,
                                            ApiSalesTaxRateRequestModel model);

                Task<ActionResponse> Delete(int salesTaxRateID);

                Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID);

                Task<List<ApiSalesTaxRateResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiSalesTaxRateResponseModel> GetStateProvinceIDTaxType(int stateProvinceID, int taxType);
        }
}

/*<Codenesium>
    <Hash>307cae43c28d9806ff46f0af86acf8c3</Hash>
</Codenesium>*/