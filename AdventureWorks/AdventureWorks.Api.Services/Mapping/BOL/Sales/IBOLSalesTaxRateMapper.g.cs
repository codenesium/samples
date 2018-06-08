using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesTaxRateMapper
        {
                BOSalesTaxRate MapModelToBO(
                        int salesTaxRateID,
                        ApiSalesTaxRateRequestModel model);

                ApiSalesTaxRateResponseModel MapBOToModel(
                        BOSalesTaxRate boSalesTaxRate);

                List<ApiSalesTaxRateResponseModel> MapBOToModel(
                        List<BOSalesTaxRate> items);
        }
}

/*<Codenesium>
    <Hash>4dfa0c7fad9ff923f6546a6e6493289e</Hash>
</Codenesium>*/