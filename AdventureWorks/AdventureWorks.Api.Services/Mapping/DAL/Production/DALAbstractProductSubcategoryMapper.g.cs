using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductSubcategoryMapper
        {
                public virtual ProductSubcategory MapBOToEF(
                        BOProductSubcategory bo)
                {
                        ProductSubcategory efProductSubcategory = new ProductSubcategory();

                        efProductSubcategory.SetProperties(
                                bo.ModifiedDate,
                                bo.Name,
                                bo.ProductCategoryID,
                                bo.ProductSubcategoryID,
                                bo.Rowguid);
                        return efProductSubcategory;
                }

                public virtual BOProductSubcategory MapEFToBO(
                        ProductSubcategory ef)
                {
                        var bo = new BOProductSubcategory();

                        bo.SetProperties(
                                ef.ProductSubcategoryID,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.ProductCategoryID,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOProductSubcategory> MapEFToBO(
                        List<ProductSubcategory> records)
                {
                        List<BOProductSubcategory> response = new List<BOProductSubcategory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0f11b4463bfb626c7089963d26bd4337</Hash>
</Codenesium>*/