using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductDescriptionMapper
        {
                public virtual ProductDescription MapBOToEF(
                        BOProductDescription bo)
                {
                        ProductDescription efProductDescription = new ProductDescription();

                        efProductDescription.SetProperties(
                                bo.Description,
                                bo.ModifiedDate,
                                bo.ProductDescriptionID,
                                bo.Rowguid);
                        return efProductDescription;
                }

                public virtual BOProductDescription MapEFToBO(
                        ProductDescription ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProductDescription();

                        bo.SetProperties(
                                ef.ProductDescriptionID,
                                ef.Description,
                                ef.ModifiedDate,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOProductDescription> MapEFToBO(
                        List<ProductDescription> records)
                {
                        List<BOProductDescription> response = new List<BOProductDescription>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>51da6fffa8c46a4ee090b34fd6b70a3a</Hash>
</Codenesium>*/