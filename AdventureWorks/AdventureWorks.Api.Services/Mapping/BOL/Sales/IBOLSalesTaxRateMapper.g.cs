using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>832c399fc99312a78c7a89269deb8cc0</Hash>
</Codenesium>*/