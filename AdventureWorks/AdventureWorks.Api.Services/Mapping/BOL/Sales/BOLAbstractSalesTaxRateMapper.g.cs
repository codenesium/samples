using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSalesTaxRateMapper
        {
                public virtual BOSalesTaxRate MapModelToBO(
                        int salesTaxRateID,
                        ApiSalesTaxRateRequestModel model
                        )
                {
                        BOSalesTaxRate boSalesTaxRate = new BOSalesTaxRate();
                        boSalesTaxRate.SetProperties(
                                salesTaxRateID,
                                model.ModifiedDate,
                                model.Name,
                                model.Rowguid,
                                model.StateProvinceID,
                                model.TaxRate,
                                model.TaxType);
                        return boSalesTaxRate;
                }

                public virtual ApiSalesTaxRateResponseModel MapBOToModel(
                        BOSalesTaxRate boSalesTaxRate)
                {
                        var model = new ApiSalesTaxRateResponseModel();

                        model.SetProperties(boSalesTaxRate.ModifiedDate, boSalesTaxRate.Name, boSalesTaxRate.Rowguid, boSalesTaxRate.SalesTaxRateID, boSalesTaxRate.StateProvinceID, boSalesTaxRate.TaxRate, boSalesTaxRate.TaxType);

                        return model;
                }

                public virtual List<ApiSalesTaxRateResponseModel> MapBOToModel(
                        List<BOSalesTaxRate> items)
                {
                        List<ApiSalesTaxRateResponseModel> response = new List<ApiSalesTaxRateResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7cf3a59e01cc4f1483bf3007079f0e2e</Hash>
</Codenesium>*/