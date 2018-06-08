using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductListPriceHistoryMapper
        {
                public virtual ProductListPriceHistory MapBOToEF(
                        BOProductListPriceHistory bo)
                {
                        ProductListPriceHistory efProductListPriceHistory = new ProductListPriceHistory();

                        efProductListPriceHistory.SetProperties(
                                bo.EndDate,
                                bo.ListPrice,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.StartDate);
                        return efProductListPriceHistory;
                }

                public virtual BOProductListPriceHistory MapEFToBO(
                        ProductListPriceHistory ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProductListPriceHistory();

                        bo.SetProperties(
                                ef.ProductID,
                                ef.EndDate,
                                ef.ListPrice,
                                ef.ModifiedDate,
                                ef.StartDate);
                        return bo;
                }

                public virtual List<BOProductListPriceHistory> MapEFToBO(
                        List<ProductListPriceHistory> records)
                {
                        List<BOProductListPriceHistory> response = new List<BOProductListPriceHistory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>502167baefbdf4af0c4ecbdd92430f61</Hash>
</Codenesium>*/