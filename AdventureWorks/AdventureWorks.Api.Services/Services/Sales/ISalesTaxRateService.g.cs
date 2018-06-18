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

                Task<List<ApiSalesTaxRateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiSalesTaxRateResponseModel> ByStateProvinceIDTaxType(int stateProvinceID, int taxType);
        }
}

/*<Codenesium>
    <Hash>1e7fdc897c109f3678e56f72d6e86542</Hash>
</Codenesium>*/