using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductModelMapper
        {
                public virtual ProductModel MapBOToEF(
                        BOProductModel bo)
                {
                        ProductModel efProductModel = new ProductModel();

                        efProductModel.SetProperties(
                                bo.CatalogDescription,
                                bo.Instructions,
                                bo.ModifiedDate,
                                bo.Name,
                                bo.ProductModelID,
                                bo.Rowguid);
                        return efProductModel;
                }

                public virtual BOProductModel MapEFToBO(
                        ProductModel ef)
                {
                        var bo = new BOProductModel();

                        bo.SetProperties(
                                ef.ProductModelID,
                                ef.CatalogDescription,
                                ef.Instructions,
                                ef.ModifiedDate,
                                ef.Name,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOProductModel> MapEFToBO(
                        List<ProductModel> records)
                {
                        List<BOProductModel> response = new List<BOProductModel>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c5ef14b4f58eb13df7ececb2afc785a8</Hash>
</Codenesium>*/