using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSalesTerritoryHistoryMapper
        {
                public virtual SalesTerritoryHistory MapBOToEF(
                        BOSalesTerritoryHistory bo)
                {
                        SalesTerritoryHistory efSalesTerritoryHistory = new SalesTerritoryHistory();

                        efSalesTerritoryHistory.SetProperties(
                                bo.BusinessEntityID,
                                bo.EndDate,
                                bo.ModifiedDate,
                                bo.Rowguid,
                                bo.StartDate,
                                bo.TerritoryID);
                        return efSalesTerritoryHistory;
                }

                public virtual BOSalesTerritoryHistory MapEFToBO(
                        SalesTerritoryHistory ef)
                {
                        var bo = new BOSalesTerritoryHistory();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.EndDate,
                                ef.ModifiedDate,
                                ef.Rowguid,
                                ef.StartDate,
                                ef.TerritoryID);
                        return bo;
                }

                public virtual List<BOSalesTerritoryHistory> MapEFToBO(
                        List<SalesTerritoryHistory> records)
                {
                        List<BOSalesTerritoryHistory> response = new List<BOSalesTerritoryHistory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5707877b74af7430cd20df4df96c5779</Hash>
</Codenesium>*/