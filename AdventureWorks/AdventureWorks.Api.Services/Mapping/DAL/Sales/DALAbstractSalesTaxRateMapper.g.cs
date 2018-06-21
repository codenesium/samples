using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSalesTaxRateMapper
        {
                public virtual SalesTaxRate MapBOToEF(
                        BOSalesTaxRate bo)
                {
                        SalesTaxRate efSalesTaxRate = new SalesTaxRate();
                        efSalesTaxRate.SetProperties(
                                bo.ModifiedDate,
                                bo.Name,
                                bo.Rowguid,
                                bo.SalesTaxRateID,
                                bo.StateProvinceID,
                                bo.TaxRate,
                                bo.TaxType);
                        return efSalesTaxRate;
                }

                public virtual BOSalesTaxRate MapEFToBO(
                        SalesTaxRate ef)
                {
                        var bo = new BOSalesTaxRate();

                        bo.SetProperties(
                                ef.SalesTaxRateID,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.Rowguid,
                                ef.StateProvinceID,
                                ef.TaxRate,
                                ef.TaxType);
                        return bo;
                }

                public virtual List<BOSalesTaxRate> MapEFToBO(
                        List<SalesTaxRate> records)
                {
                        List<BOSalesTaxRate> response = new List<BOSalesTaxRate>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>92653afd4a88b00c913fb9b0d3b7f946</Hash>
</Codenesium>*/