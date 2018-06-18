using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductCategoryMapper
        {
                public virtual ProductCategory MapBOToEF(
                        BOProductCategory bo)
                {
                        ProductCategory efProductCategory = new ProductCategory();

                        efProductCategory.SetProperties(
                                bo.ModifiedDate,
                                bo.Name,
                                bo.ProductCategoryID,
                                bo.Rowguid);
                        return efProductCategory;
                }

                public virtual BOProductCategory MapEFToBO(
                        ProductCategory ef)
                {
                        var bo = new BOProductCategory();

                        bo.SetProperties(
                                ef.ProductCategoryID,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOProductCategory> MapEFToBO(
                        List<ProductCategory> records)
                {
                        List<BOProductCategory> response = new List<BOProductCategory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>00a0e96f6818c6893ab9402b0160f039</Hash>
</Codenesium>*/