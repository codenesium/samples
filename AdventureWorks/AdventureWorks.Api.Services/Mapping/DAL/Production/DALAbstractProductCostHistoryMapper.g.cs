using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductCostHistoryMapper
        {
                public virtual ProductCostHistory MapBOToEF(
                        BOProductCostHistory bo)
                {
                        ProductCostHistory efProductCostHistory = new ProductCostHistory();

                        efProductCostHistory.SetProperties(
                                bo.EndDate,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.StandardCost,
                                bo.StartDate);
                        return efProductCostHistory;
                }

                public virtual BOProductCostHistory MapEFToBO(
                        ProductCostHistory ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProductCostHistory();

                        bo.SetProperties(
                                ef.ProductID,
                                ef.EndDate,
                                ef.ModifiedDate,
                                ef.StandardCost,
                                ef.StartDate);
                        return bo;
                }

                public virtual List<BOProductCostHistory> MapEFToBO(
                        List<ProductCostHistory> records)
                {
                        List<BOProductCostHistory> response = new List<BOProductCostHistory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8d9002058a7c63c05cdb36b2d5cf99cc</Hash>
</Codenesium>*/