using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductProductPhotoMapper
        {
                public virtual ProductProductPhoto MapBOToEF(
                        BOProductProductPhoto bo)
                {
                        ProductProductPhoto efProductProductPhoto = new ProductProductPhoto();
                        efProductProductPhoto.SetProperties(
                                bo.ModifiedDate,
                                bo.Primary,
                                bo.ProductID,
                                bo.ProductPhotoID);
                        return efProductProductPhoto;
                }

                public virtual BOProductProductPhoto MapEFToBO(
                        ProductProductPhoto ef)
                {
                        var bo = new BOProductProductPhoto();

                        bo.SetProperties(
                                ef.ProductID,
                                ef.ModifiedDate,
                                ef.Primary,
                                ef.ProductPhotoID);
                        return bo;
                }

                public virtual List<BOProductProductPhoto> MapEFToBO(
                        List<ProductProductPhoto> records)
                {
                        List<BOProductProductPhoto> response = new List<BOProductProductPhoto>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>528b7a2216341d367944e9c2f1029fd3</Hash>
</Codenesium>*/