using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductModelProductDescriptionCultureMapper
        {
                public virtual ProductModelProductDescriptionCulture MapBOToEF(
                        BOProductModelProductDescriptionCulture bo)
                {
                        ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();

                        efProductModelProductDescriptionCulture.SetProperties(
                                bo.CultureID,
                                bo.ModifiedDate,
                                bo.ProductDescriptionID,
                                bo.ProductModelID);
                        return efProductModelProductDescriptionCulture;
                }

                public virtual BOProductModelProductDescriptionCulture MapEFToBO(
                        ProductModelProductDescriptionCulture ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProductModelProductDescriptionCulture();

                        bo.SetProperties(
                                ef.ProductModelID,
                                ef.CultureID,
                                ef.ModifiedDate,
                                ef.ProductDescriptionID);
                        return bo;
                }

                public virtual List<BOProductModelProductDescriptionCulture> MapEFToBO(
                        List<ProductModelProductDescriptionCulture> records)
                {
                        List<BOProductModelProductDescriptionCulture> response = new List<BOProductModelProductDescriptionCulture>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>54f3e39dc357da02103896197e272e62</Hash>
</Codenesium>*/