using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>4f51e38c7dce40d06a32427acaaed161</Hash>
</Codenesium>*/