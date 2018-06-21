using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>6c46cbd03f81abe7fa08077c8f1564f9</Hash>
</Codenesium>*/