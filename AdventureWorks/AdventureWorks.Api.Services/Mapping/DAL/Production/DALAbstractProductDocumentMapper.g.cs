using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductDocumentMapper
        {
                public virtual ProductDocument MapBOToEF(
                        BOProductDocument bo)
                {
                        ProductDocument efProductDocument = new ProductDocument();

                        efProductDocument.SetProperties(
                                bo.DocumentNode,
                                bo.ModifiedDate,
                                bo.ProductID);
                        return efProductDocument;
                }

                public virtual BOProductDocument MapEFToBO(
                        ProductDocument ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProductDocument();

                        bo.SetProperties(
                                ef.ProductID,
                                ef.DocumentNode,
                                ef.ModifiedDate);
                        return bo;
                }

                public virtual List<BOProductDocument> MapEFToBO(
                        List<ProductDocument> records)
                {
                        List<BOProductDocument> response = new List<BOProductDocument>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>37258a546c8426e880672f623a6bab7d</Hash>
</Codenesium>*/