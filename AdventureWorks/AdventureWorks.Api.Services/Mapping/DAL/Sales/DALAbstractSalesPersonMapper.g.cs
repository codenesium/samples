using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSalesPersonMapper
        {
                public virtual SalesPerson MapBOToEF(
                        BOSalesPerson bo)
                {
                        SalesPerson efSalesPerson = new SalesPerson();

                        efSalesPerson.SetProperties(
                                bo.Bonus,
                                bo.BusinessEntityID,
                                bo.CommissionPct,
                                bo.ModifiedDate,
                                bo.Rowguid,
                                bo.SalesLastYear,
                                bo.SalesQuota,
                                bo.SalesYTD,
                                bo.TerritoryID);
                        return efSalesPerson;
                }

                public virtual BOSalesPerson MapEFToBO(
                        SalesPerson ef)
                {
                        var bo = new BOSalesPerson();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.Bonus,
                                ef.CommissionPct,
                                ef.ModifiedDate,
                                ef.Rowguid,
                                ef.SalesLastYear,
                                ef.SalesQuota,
                                ef.SalesYTD,
                                ef.TerritoryID);
                        return bo;
                }

                public virtual List<BOSalesPerson> MapEFToBO(
                        List<SalesPerson> records)
                {
                        List<BOSalesPerson> response = new List<BOSalesPerson>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ee3a82a97421c9e226f708c14fcf4f6b</Hash>
</Codenesium>*/