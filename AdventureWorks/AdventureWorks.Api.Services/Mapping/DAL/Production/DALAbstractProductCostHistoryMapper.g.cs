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
    <Hash>eeccfa77f59d4294ae1b9e0d01ed8b21</Hash>
</Codenesium>*/