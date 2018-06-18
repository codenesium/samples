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
    <Hash>2e4629173d8f70be623cc3dcaf2d119f</Hash>
</Codenesium>*/